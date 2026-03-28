using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace MyStuff11net
{
    public struct CatalogHeader
    {
        public short nNum1;             // Index  0, + 2 byte on any Int16 or short         
        public short nNum2;             // Index  2, + 2 byte on any Int16 or short
        public int nThumbCount;         // Index  4, + 4 byte on any Int32
        public int nThumbWidth;         // Index  8, + 4 byte on any Int32
        public int nThumbHeight;        // Index  12, + 4 byte on any Int32
    }

    public struct CatalogItem
    {

        public int nItemSize;           // Index 16, + 4 byte on any Int32
        public int nItemID;             // Index 20, + 4 byte on any Int32
        public short nNum3;             // Index 24, + 2 byte on any Int16 or short
        public short nNum4;             // Index 26, + 2 byte on any Int16 or short
        public short nNum5;             // Index 28, + 2 byte on any Int16 or short
        public short nNum6;             // Index 30, + 2 byte on any Int16 or short
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string strFileName;      // Index 30, + SizeConst byte
        public short nNum7;             // Index 30 + SizeConst byte, + 2 byte on any Int16 or short
    }


    /// <summary>
    /// Summary description for ThumbDB.
    /// </summary>
    public class ThumbDB
    {
        byte[] _buffer;
        GCHandle _handle;
        CatalogHeader _catalogHeader;


        private ArrayList m_arCatalogItems = new ArrayList();
        private string m_strThumbFile;

        public ThumbDB(string strThumbFile)
        {
            if (!File.Exists(strThumbFile))
                return;

            m_strThumbFile = strThumbFile;
            LoadCatalog();
        }

        public string[] GetThumbfiles()
        {
            string[] strFiles = new string[m_arCatalogItems.Count];

            int nIndex = 0;
            foreach (CatalogItem item in m_arCatalogItems)
            {
                strFiles[nIndex] = item.strFileName;
                nIndex++;
            }

            return strFiles;
        }

        /// <summary>
        /// Return ThumbImage in a byte[] format.
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public byte[] GetThumbData(string strFileName)
        {
            IStorageWrapper wrapper = new IStorageWrapper(m_strThumbFile, false);
            foreach (CatalogItem catItem in m_arCatalogItems)
            {
                if (catItem.strFileName == strFileName)
                {
                    string strStreamName = BuildReverseString(catItem.nItemID);
                    FileObject fileObject = wrapper.OpenUCOMStream(null, strStreamName);

                    if (fileObject == null || fileObject.Length == 0) continue;

                    Byte[] byRawData = new byte[fileObject.Length];
                    fileObject.ReadExactly(byRawData, 0, (int)fileObject.Length);
                    fileObject.Close();

                    // 3 ints of header data need to be removed
                    // Don't know what first int is.
                    // 2nd int is thumb index
                    // 3rd is size of thumbnail data.
                    Byte[] byData = new byte[byRawData.Length - 12];
                    for (int nIndex = 0; nIndex < byData.Length; nIndex++)
                        byData[nIndex] = byRawData[nIndex + 12];

                    return byData;
                }
            }

            return null;
        }

        public Size GetThumbnailSize(string strFileName)
        {
            Size xyThumb = new Size();
            foreach (CatalogItem catItem in m_arCatalogItems)
            {
                if (catItem.strFileName == strFileName)
                {
                    xyThumb.Width = xyThumb.Height = catItem.nItemSize;
                    break;
                }
            }

            return xyThumb;
        }

        public Image GetThumbnailImage(string strFileName)
        {
            Byte[] byThumbData = GetThumbData(strFileName);
            if (byThumbData == null)
                return null;

            //     String strTempFile = Path.GetTempFileName();
            MemoryStream ms = new MemoryStream(byThumbData);
            //     BinaryWriter binWriter = new BinaryWriter(File.Open(strTempFile, FileMode.OpenOrCreate));
            //     binWriter.Write(byThumbData);
            //     binWriter.Close();

            if (ms.Length > 0)
            {
                try
                {
                    //  Image img1 = Image.FromFile(strTempFile);
                    Image img2 = null;
                    //  if (img1 != null)
                    img2 = Image.FromStream(ms);

                    //  img1.Dispose();
                    //  img1 = null;

                    //  if (img2 != null)
                    //  {
                    //      File.Delete(strTempFile);
                    return img2;
                    //  }
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            //    File.Delete(strTempFile);

            return null;
        }


        private void LoadCatalogHeader()
        {
            IStorageWrapper wrapper = new IStorageWrapper(m_strThumbFile, false);
            FileObject fileObject = wrapper.OpenUCOMStream(null, "Catalog");

            if (fileObject == null)
                return;

            string strTextData = string.Empty;
            Byte[] byFileData = new Byte[fileObject.Length];
            fileObject.ReadExactly(byFileData, 0, (int)fileObject.Length);

            using (FileStream fs = File.Open(m_strThumbFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fileObject))
            using (BinaryReader _binaryreader = new BinaryReader(bs, Encoding.Default))
            {
                _binaryreader.BaseStream.Position = 0;
                // Read the header into a buffer
                _buffer = _binaryreader.ReadBytes(Marshal.SizeOf(typeof(CatalogHeader)));

                // Marshall the header into a DBFHeader structure
                _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
                _catalogHeader = (CatalogHeader)Marshal.PtrToStructure(_handle.AddrOfPinnedObject(), typeof(CatalogHeader));
                _handle.Free();
            }
        }

        private void LoadCatalog()
        {
            LoadCatalogHeader();

            IStorageWrapper wrapper = new IStorageWrapper(m_strThumbFile, false);
            FileObject fileObject = wrapper.OpenUCOMStream(null, "Catalog");
            string strTextData = string.Empty;
            if (fileObject != null)
            {
                Byte[] byFileData = new Byte[fileObject.Length];
                fileObject.ReadExactly(byFileData, 0, (int)fileObject.Length);
                MemoryStream ms = new MemoryStream(byFileData);
                BinaryReader br = new BinaryReader(ms);
                CatalogHeader ch = new CatalogHeader();

                ch.nNum1 = br.ReadInt16();
                ch.nNum2 = br.ReadInt16();
                ch.nThumbCount = br.ReadInt32();
                ch.nThumbWidth = br.ReadInt32();
                ch.nThumbHeight = br.ReadInt32();

                //                          ch.nThumbCount
                for (int nIndex = 0; nIndex < ch.nThumbCount; nIndex++)
                {
                    CatalogItem item = new CatalogItem();
                    item.nItemSize = br.ReadInt32();
                    item.nItemID = br.ReadInt32();
                    item.nNum3 = br.ReadInt16();
                    item.nNum4 = br.ReadInt16();
                    item.nNum5 = br.ReadInt16();
                    item.nNum6 = br.ReadInt16();
                    ushort usChar;
                    while ((usChar = br.ReadUInt16()) != 0x0000)
                    {
                        Byte[] byChar = new Byte[2];
                        byChar[0] = (Byte)(usChar & 0x00FF);
                        byChar[1] = (Byte)((usChar & 0xFF00) >> 8);
                        item.strFileName += Encoding.Unicode.GetString(byChar);
                    }
                    item.nNum7 = br.ReadInt16();
                    m_arCatalogItems.Add(item);
                }
            }
        }

        private string BuildReverseString(int nItemID)
        {
            string strItem = nItemID.ToString();
            string strReverse = "";
            for (int nIndex = strItem.Length - 1; nIndex >= 0; nIndex--)
                strReverse += strItem[nIndex];

            return strReverse;
        }
    }
}
