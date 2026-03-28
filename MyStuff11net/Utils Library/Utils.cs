using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace MyStuff11net
{
    internal class AssemblyInfo
    {
        #region Properties

        Assembly m_Assembly;
        public string AssemblyName
        {
            get
            {
                return m_Assembly.GetName().Name;
            }
        }

        string m_CompanyName;
        public string CompanyName
        {
            get
            {
                if (m_CompanyName == null)
                {
                    AssemblyCompanyAttribute attribute = (AssemblyCompanyAttribute)GetAttribute(typeof(AssemblyCompanyAttribute));
                    m_CompanyName = attribute == null ? "" : attribute.Company;
                }

                return m_CompanyName;
            }
        }

        string m_Copyright;
        public string Copyright
        {
            get
            {
                if (m_Copyright == null)
                {
                    AssemblyCopyrightAttribute attribute = (AssemblyCopyrightAttribute)GetAttribute(typeof(AssemblyCopyrightAttribute));
                    m_Copyright = attribute == null ? "" : attribute.Copyright;
                }

                return m_Copyright;
            }
        }

        string m_Description;
        public string Description
        {
            get
            {
                if (m_Description == null)
                {
                    AssemblyDescriptionAttribute attribute = (AssemblyDescriptionAttribute)GetAttribute(typeof(AssemblyDescriptionAttribute));
                    m_Description = attribute == null ? "" : attribute.Description;
                }

                return m_Description;
            }
        }

        public string DirectoryPath
        {
            get
            {
                return Path.GetDirectoryName(m_Assembly.Location);
            }
        }


        public ReadOnlyCollection<Assembly> LoadedAssemblies
        {
            get
            {
                Collection<Assembly> list = new Collection<Assembly>();
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    list.Add(assembly);
                }
                return new ReadOnlyCollection<Assembly>(list);
            }
        }

        string m_ProductName;
        public string ProductName
        {
            get
            {
                if (m_ProductName == null)
                {
                    AssemblyProductAttribute attribute = (AssemblyProductAttribute)GetAttribute(typeof(AssemblyProductAttribute));
                    m_ProductName = attribute == null ? "" : attribute.Product;
                }
                return m_ProductName;
            }
        }

        public string StackTrace
        {
            get
            {
                return Environment.StackTrace;
            }
        }

        string m_Title;
        public string Title
        {
            get
            {
                if (m_Title == null)
                {
                    AssemblyTitleAttribute attribute = (AssemblyTitleAttribute)GetAttribute(typeof(AssemblyTitleAttribute));
                    m_Title = attribute == null ? "" : attribute.Title;
                }
                return m_Title;
            }
        }

        string m_Trademark;
        public string Trademark
        {
            get
            {
                if (m_Trademark == null)
                {
                    AssemblyTrademarkAttribute attribute = (AssemblyTrademarkAttribute)GetAttribute(typeof(AssemblyTrademarkAttribute));
                    m_Trademark = attribute == null ? "" : attribute.Trademark;
                }
                return m_Trademark;
            }
        }

        public Version Version
        {
            get
            {
                return m_Assembly.GetName().Version;
            }
        }

        public long WorkingSet
        {
            get
            {
                return Environment.WorkingSet;
            }
        }

        #endregion

        public AssemblyInfo(Assembly currentAssembly)
        {
            if (currentAssembly == null)
                throw new ArgumentNullException("currentAssembly");

            m_Assembly = currentAssembly;
        }

        private object GetAttribute(Type attributeType)
        {
            object[] customAttributes = m_Assembly.GetCustomAttributes(attributeType, true);

            if (customAttributes.Length == 0)
                return null;

            return customAttributes[0];
        }
    }

    sealed class Application1
    {
        static AssemblyInfo info;
        public static AssemblyInfo Info
        {
            get
            {
                if (info == null)
                {
                    Assembly entryAssembly = Assembly.GetEntryAssembly();

                    if (entryAssembly == null)
                        entryAssembly = Assembly.GetCallingAssembly();

                    info = new AssemblyInfo(entryAssembly);
                }

                return info;
            }
        }

        public static bool Restart { get; set; }

        public static string LocalUserAppDataPath
        {
            get
            {
                return GetDataPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            }
        }

        public static string UserAppDataPath
        {
            get
            {
                return GetDataPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        static string GetDataPath(string basePath)
        {
            string companyName = Info.CompanyName;
            string productName = Info.ProductName;
            string productVersion = Info.Version.ToString();

            string dataPath = string.Format(
                CultureInfo.CurrentCulture,
                "{0}{4}{1}{4}{2}{4}{3}",
                basePath, companyName, productName, productVersion,
                Path.DirectorySeparatorChar);

            if (!(Directory.Exists(dataPath)))
                Directory.CreateDirectory(dataPath);

            return dataPath;
        }
    }
}

namespace MyStuff11net
{
    public static class Utils
    {
        /// <summary>
        /// Replaces a given character with another character in a string. 
        /// The replacement is case insensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="charToReplace">The character to replace</param>
        /// <param name="replacement">The character by which to be replaced</param>
        /// <returns>Copy of string with the characters replaced</returns>
        public static string CaseInsenstiveReplace(this string val, char charToReplace, char replacement)
        {
            Regex regEx = new Regex(charToReplace.ToString(), RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return regEx.Replace(val, replacement.ToString());
        }

        /// <summary>
        /// Replaces a given string with another string in a given string. 
        /// The replacement is case insensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="stringToReplace">The string to replace</param>
        /// <param name="replacement">The string by which to be replaced</param>
        /// <returns>Copy of string with the string replaced</returns>
        public static string CaseInsenstiveReplace(this string val, string stringToReplace, string replacement)
        {
            Regex regEx = new Regex(stringToReplace, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return regEx.Replace(val, replacement);
        }

        /// <summary>
        /// Replaces the first occurrence of a string with another string in a given string
        /// The replacement is case insensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="stringToReplace">The string to replace</param>
        /// <param name="replacement">The string by which to be replaced</param>
        /// <returns>Copy of string with the string replaced</returns>
        public static string ReplaceFirst(this string val, string stringToReplace, string replacement)
        {
            Regex regEx = new Regex(stringToReplace, RegexOptions.Multiline);
            return regEx.Replace(val, replacement, 1);
        }

        /// <summary>
        /// Replaces the first occurrence of a character with another character in a given string
        /// The replacement is case insensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="charToReplace">The character to replace</param>
        /// <param name="replacement">The character by which to replace</param>
        /// <returns>Copy of string with the character replaced</returns>
        public static string ReplaceFirst(this string val, char charToReplace, char replacement)
        {
            Regex regEx = new Regex(charToReplace.ToString(), RegexOptions.Multiline);
            return regEx.Replace(val, replacement.ToString(), 1);
        }

        /// <summary>
        /// Replaces the last occurrence of a character with another character in a given string
        /// The replacement is case insensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="charToReplace">The character to replace</param>
        /// <param name="replacement">The character by which to replace</param>
        /// <returns>Copy of string with the character replaced</returns>
        public static string ReplaceLast(this string val, char charToReplace, char replacement)
        {
            int index = val.LastIndexOf(charToReplace);
            if (index < 0)
            {
                return val;
            }
            else
            {
                StringBuilder sb = new StringBuilder(val.Length - 2);
                sb.Append(val.Substring(0, index));
                sb.Append(replacement);
                sb.Append(val.Substring(index + 1,
                   val.Length - index - 1));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Replaces the last occurrence of a string with another string in a given string
        /// The replacement is case insensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="stringToReplace">The string to replace</param>
        /// <param name="replacement">The string by which to be replaced</param>
        /// <returns>Copy of string with the string replaced</returns>
        public static string ReplaceLast(this string val, string stringToReplace, string replacement)
        {
            int index = val.LastIndexOf(stringToReplace);
            if (index < 0)
            {
                return val;
            }
            else
            {
                StringBuilder sb = new StringBuilder(val.Length - stringToReplace.Length + replacement.Length);
                sb.Append(val.Substring(0, index));
                sb.Append(replacement);
                sb.Append(val.Substring(index + stringToReplace.Length,
                   val.Length - index - stringToReplace.Length));

                return sb.ToString();
            }
        }

        /// <summary>
        /// Removes occurrences of words in a string
        /// The match is case sensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="filterWords">Array of words to be removed from the string</param>
        /// <returns>Copy of the string with the words removed</returns>
        public static string RemoveWords(this string val, params string[] filterWords)
        {
            return MaskWords(val, char.MinValue, filterWords);
        }

        /// <summary>
        /// Masks the occurence of words in a string with a given character
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="mask">The character mask to apply</param>
        /// <param name="filterWords">The words to be replaced</param>
        /// <returns>The copy of string with the mask applied</returns>
        public static string MaskWords(this string val, char mask, params string[] filterWords)
        {
            string stringMask = mask == char.MinValue ?
               string.Empty : mask.ToString();
            string totalMask = stringMask;

            foreach (string s in filterWords)
            {
                Regex regEx = new Regex(s, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (stringMask.Length > 0)
                {
                    for (int i = 1; i < s.Length; i++)
                        totalMask += stringMask;
                }

                val = regEx.Replace(val, totalMask);
                totalMask = stringMask;
            }
            return val;
        }

        /// <summary>
        /// Left pads the passed string using the passed pad string for the total number of spaces. 
        /// It will not cut-off the pad even if it causes the string to exceed the total width.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pad">The pad string</param>
        /// <param name="totalWidth">The total width of the resulting string</param>
        /// <returns>Copy of string with the padding applied</returns>
        public static string PadLeft(this string val, string pad, int totalWidth)
        {
            return PadLeft(val, pad, totalWidth, false);
        }

        /// <summary>
        /// Left pads the passed string using the passed pad string for the total number of spaces. 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pad">The pad string</param>
        /// <param name="totalWidth">The total width of the resulting string</param>
        /// <param name="cutOff">True to cut off the characters if exceeds the specified width</param>
        /// <returns>Copy of string with the padding applied</returns>
        public static string PadLeft(this string val, string pad, int totalWidth, bool cutOff)
        {
            if (val.Length >= totalWidth)
                return val;

            int padCount = pad.Length;
            string paddedString = val;

            while (paddedString.Length < totalWidth)
            {
                paddedString += pad;
            }

            if (cutOff)
                paddedString = paddedString.Substring(0, totalWidth);
            return paddedString;
        }

        /// <summary>
        /// Right pads the passed string using the passed pad string for the total number of spaces. 
        /// It will not cut-off the pad even if it causes the string to exceed the total width.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pad">The pad string</param>
        /// <param name="totalWidth">The total width of the resulting string</param>
        /// <returns>Copy of string with the padding applied</returns>
        public static string PadRight(this string val, string pad, int totalWidth)
        {
            return PadRight(val, pad, totalWidth, false);
        }

        /// <summary>
        /// Right pads the passed string using the passed pad string for the total number of spaces. 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pad">The pad string</param>
        /// <param name="totalWidth">The total width of the resulting string</param>
        /// <param name="cutOff">True to cut off the characters if exceeds the specified width</param>
        /// <returns>Copy of string with the padding applied</returns>
        public static string PadRight(this string val, string pad, int totalWidth, bool cutOff)
        {
            if (val.Length >= totalWidth)
                return val;

            string paddedString = string.Empty;

            while (paddedString.Length < totalWidth - val.Length)
            {
                paddedString += pad;
            }

            if (cutOff)
                paddedString = paddedString.Substring(0, totalWidth - val.Length);
            paddedString += val;
            return paddedString;
        }

        /// <summary>
        /// Removes new line characters from a string
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Returns copy of string with the new line characters removed</returns>
        public static string RemoveNewLines(this string val)
        {
            return RemoveNewLines(val, false);
        }

        /// <summary>
        /// Removes new line characters from a string
        /// Test Coverage: Included
        /// </summary>
        /// <param name="input"></param>
        /// <param name="addSpace">True to add a space after removing a new line character</param>
        /// <returns>Returns a copy of the string after removing the new line character</returns>
        public static string RemoveNewLines(this string input, bool addSpace)
        {
            string replace = addSpace ? " " : string.Empty;
            const string pattern = @"[\r|\n]";
            Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return regEx.Replace(input, replace);
        }

        /// <summary>
        /// Removes a non numeric character from a string
        /// Test Coverage: Included
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Copy of the string after removing non numeric characters</returns>
        public static string RemoveNonNumeric(this string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                if (Char.IsNumber(s[i]))
                    sb.Append(s[i]);
            return sb.ToString();
        }

        /// <summary>
        /// Removes numeric characters from a given string
        /// Test Coverage: Included
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Copy of the string after removing the numeric characters</returns>
        public static string RemoveNumeric(this string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                if (!Char.IsNumber(s[i]))
                    sb.Append(s[i]);
            return sb.ToString();
        }

        /// <summary>
        /// Reverses a string
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Copy of the reversed string</returns>
        public static string Reverse(this string val)
        {
            char[] reverse = new char[val.Length];
            for (int i = 0, k = val.Length - 1; i < val.Length; i++, k--)
            {
                if (char.IsSurrogate(val[k]))
                {
                    reverse[i + 1] = val[k--];
                    reverse[i++] = val[k];
                }
                else
                {
                    reverse[i] = val[k];
                }
            }
            return new string(reverse);
        }

        /// <summary>
        /// Changes the string as sentence case.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Copy of string with the sentence case applied</returns>
        public static string SentenceCase(this string val)
        {
            if (val.Length < 1)
                return val;

            string sentence = val.ToLower();
            return sentence[0].ToString().ToUpper() +
               sentence.Substring(1);
        }

        /// <summary>
        /// Changes the string as title case.
        /// Ignores short words in the string.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Copy of string with the title case applied</returns>
        public static string TitleCase(this string val)
        {
            if (val.Length == 0) return string.Empty;
            return TitleCase(val, true);
        }

        /// <summary>
        /// Changes the string as title case.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="ignoreShortWords">true to ignore short words</param>
        /// <returns>Copy of string with the title case applied</returns>
        public static string TitleCase(this string val, bool ignoreShortWords)
        {
            if (val.Length == 0) return string.Empty;

            IList<string> ignoreWords = null;
            if (ignoreShortWords)
            {
                //TODO: Add more ignore words? Changes the string as title case.
                ignoreWords = new List<string>();
                ignoreWords.Add("a");
                ignoreWords.Add("is");
                ignoreWords.Add("was");
                ignoreWords.Add("the");
            }

            string[] tokens = val.Split(' ');
            StringBuilder sb = new StringBuilder(val.Length);
            foreach (string s in tokens)
            {
                if (ignoreShortWords && s != tokens[0]
                    && ignoreWords.Contains(s.ToLower()))
                {
                    sb.Append(s + " ");
                }
                else
                {
                    sb.Append(s[0].ToString().ToUpper());
                    sb.Append(s.Substring(1).ToLower());
                    sb.Append(" ");
                }
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Removes multiple spaces between words
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Returns a copy of the string after removing the extra spaces</returns>
        public static string TrimIntraWords(this string val)
        {
            Regex regEx = new Regex(@"[\s]+");
            return regEx.Replace(val, " ");
        }

        /// <summary>
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="charCount">The number of characters after which it should wrap the text</param>
        /// <returns>The copy of the string after applying the Wrap</returns>
        public static string WordWrap(this string val, int charCount)
        {
            return WordWrap(val, charCount, false, Environment.NewLine);
        }

        /// <summary>
        /// Wraps the passed string at the passed total number of characters (if cuttOff is true)
        /// or at the next whitespace (if cutOff is false). 
        /// Uses the environment new line symbol for the break text
        /// </summary>
        /// <param name="val"></param>
        /// <param name="charCount">The number of characters after which to break</param>
        /// <param name="cutOff">true to break at specific</param>
        /// <returns></returns>
        public static string WordWrap(this string val, int charCount, bool cutOff)
        {
            return WordWrap(val, charCount, cutOff, Environment.NewLine);
        }

        private static string WordWrap(this string val, int charCount, bool cutOff, string breakText)
        {
            StringBuilder sb = new StringBuilder(val.Length + 100);
            int counter = 0;

            if (cutOff)
            {
                while (counter < val.Length)
                {
                    if (val.Length > counter + charCount)
                    {
                        sb.Append(val.Substring(counter, charCount));
                        sb.Append(breakText);
                    }
                    else
                    {
                        sb.Append(val.Substring(counter));
                    }
                    counter += charCount;
                }
            }
            else
            {
                string[] strings = val.Split(' ');
                for (int i = 0; i < strings.Length; i++)
                {
                    // added one to represent the space.
                    counter += strings[i].Length + 1;
                    if (i != 0 && counter > charCount)
                    {
                        sb.Append(breakText);
                        counter = 0;
                    }

                    sb.Append(strings[i] + ' ');
                }
            }
            // to get rid of the extra space at the end.
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Converts an list of string to CSV string representation.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="insertSpaces">True to add spaces after each comma</param>
        /// <returns>CSV representation of the data</returns>
        public static string ToCSV(this IEnumerable<string> val, bool insertSpaces)
        {
            if (insertSpaces)
                return string.Join(", ", val.ToArray());
            else
                return string.Join(",", val.ToArray());
        }

        /// <summary>
        /// Converts an list of characters to CSV string representation.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="insertSpaces">True to add spaces after each comma</param>
        /// <returns>CSV representation of the data</returns>
        public static string ToCSV(this IEnumerable<char> val, bool insertSpaces)
        {
            List<string> casted = new List<string>();
            foreach (var item in val)
                casted.Add(item.ToString());

            if (insertSpaces)
                return string.Join(", ", casted.ToArray());
            else
                return string.Join(",", casted.ToArray());
        }

        /// <summary>
        /// Converts CSV to list of string.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>IEnumerable collection of string</returns>
        public static IEnumerable<string> ListFromCSV(this string val)
        {
            string[] split = val.Split(',');
            foreach (string item in split)
            {
                item.Trim();
            }
            return new List<string>(split);
        }

        /// <summary>
        /// Converts long to words
        /// Test Coverage: Included
        /// </summary>
        /// <param name="var"></param>
        /// <returns>The representation of the number in words</returns>
        public static string ToWords(this long var)
        {
            return NumberArticulator.ConvertNumberToWord(var);
        }

        /// <summary>
        /// Converts integer to words
        /// Test Coverage: Included
        /// </summary>
        /// <param name="var"></param>
        /// <returns>The representation of the number in words</returns>
        public static string ToWords(this int var)
        {
            return NumberArticulator.ConvertNumberToWord((long)var);
        }

        /// <summary>
        /// Returns Age given the Date Of Birth.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns>The Age</returns>
        public static Age Age(this DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            if (today < birthDate)
                throw new InvalidOperationException("birth date cannot be greater than the current date");

            int ageInYears = 0;
            int ageInMonths = 0;
            int ageInDays = 0;

            CalculateAge(birthDate, today, out ageInYears, out ageInMonths, out ageInDays);
            return CreateAge(ageInYears, ageInMonths, ageInDays);
        }

        /// <summary>
        /// Calculates Age.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="birthDate">Date Of Birth.</param>
        /// <param name="futureDate">The Date at which the age has to be calculated.</param>
        /// <returns>Age at a particular date.</returns>
        public static Age AgeAt(this DateTime birthDate, DateTime futureDate)
        {
            if (futureDate < birthDate)
                throw new InvalidOperationException("Future date cannot be less than the date of birth");
            int ageInYears = 0;
            int ageInMonths = 0;
            int ageInDays = 0;

            CalculateAge(birthDate, futureDate, out ageInYears, out ageInMonths, out ageInDays);
            return CreateAge(ageInYears, ageInMonths, ageInDays);
        }

        /// <summary>
        /// Convert to Ordinal number
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>String representation of the Ordinal number</returns>
        public static string ToOrdinal(this int val)
        {
            if (val <= 0) throw new ArgumentException("Cardinal must be positive.");

            int lastTwoDigits = val % 100;
            int lastDigit = lastTwoDigits % 10;
            string suffix;
            switch (lastDigit)
            {
                case 1:
                    suffix = "st";
                    break;

                case 2:
                    suffix = "nd";
                    break;

                case 3:
                    suffix = "rd";
                    break;

                default:
                    suffix = "th";
                    break;
            }
            if (11 <= lastTwoDigits && lastTwoDigits <= 13)
            {
                suffix = "th";
            }
            return string.Format("{0}{1}", val, suffix);
        }

        #region -- Private Methods --

        private static void CalculateAge(DateTime adtDateOfBirth, DateTime referenceDate, out int noOfYears, out int noOfMonths, out int noOfDays)
        {
            DateTime adtCurrentDate = referenceDate;

            noOfDays = adtCurrentDate.Day - adtDateOfBirth.Day;
            noOfMonths = adtCurrentDate.Month - adtDateOfBirth.Month;
            noOfYears = adtCurrentDate.Year - adtDateOfBirth.Year;

            if (noOfDays < 0)
            {
                noOfDays += DateTime.DaysInMonth(adtCurrentDate.Year, adtCurrentDate.Month);
                noOfMonths--;
            }

            if (noOfMonths < 0)
            {
                noOfMonths += 12;
                noOfYears--;
            }
        }

        private static Age CreateAge(int years, int Months, int days)
        {
            Age age = new Age();
            age.Years = years;
            age.Months = Months;
            age.Days = days;
            return age;
        }

        #endregion    



        /// <summary>
        /// Represents TimeSpan in words
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>String representation of the timespan</returns>
        public static string ToWords(this TimeSpan val)
        {
            return TimeSpanArticulator.Articulate(val, TemporalGroupType.day
                | TemporalGroupType.hour
                | TemporalGroupType.minute
                | TemporalGroupType.month
                | TemporalGroupType.second
                | TemporalGroupType.week
                | TemporalGroupType.year);
        }

        /// <summary>
        /// Converts Datetime value at midnight
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>DateTime value with time set to Midnight</returns>
        public static DateTime MidNight(this DateTime val)
        {
            return new DateTime(val.Year, val.Month, val.Day, 0, 0, 0);
        }

        /// <summary>
        /// Converts Datetime value at noon
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>DateTime value with time set to Noon</returns>
        public static DateTime Noon(this DateTime val)
        {
            return new DateTime(val.Year, val.Month, val.Day, 12, 0, 0);
        }

        /// <summary>
        /// Checks if the Datetime lies within a given range
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="floor">The floor value of the range</param>
        /// <param name="ceiling">The ceiling value of the range</param>
        /// <param name="includeBase">True to include the floor and ceiling values for comparison</param>
        /// <returns>Returns true if the value lies within the range</returns>
        public static bool IsWithinRange(this DateTime val, DateTime floor, DateTime ceiling, bool includeBase)
        {
            if (floor > ceiling)
                throw new InvalidOperationException("floor value cannot be greater than ceiling value");
            if (floor == ceiling)
                throw new InvalidOperationException("floor value cannot be equal to ceiling value");

            if (includeBase)
                return (val >= floor && val <= ceiling);
            else
                return (val > floor && val < ceiling);
        }

        /// <summary>
        /// Calculates the TimeSpan between the current Datetime and the provided Datetime
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>TimeSpan between the current DateTime & the provided DateTime</returns>
        public static TimeSpan GetTimeSpan(this DateTime val)
        {
            TimeSpan dateDiff;
            if (val < DateTime.Now)
                dateDiff = DateTime.Now.Subtract(val);
            else if (val > DateTime.Now)
                dateDiff = val.Subtract(DateTime.Now);
            else
                dateDiff = new TimeSpan();
            return dateDiff;
        }





        public static string GetFileSize(this long bytes)
        {
            if (bytes >= 1073741824)
            {
                Decimal size = Decimal.Divide(bytes, 1073741824);
                return string.Format("{0:##.##} GB", size);
            }
            else if (bytes >= 1048576)
            {
                Decimal size = Decimal.Divide(bytes, 1048576);
                return string.Format("{0:##.##} MB", size);
            }
            else if (bytes >= 1024)
            {
                Decimal size = Decimal.Divide(bytes, 1024);
                return string.Format("{0:##.##} KB", size);
            }
            else if (bytes > 0 & bytes < 1024)
            {
                Decimal size = bytes;
                return string.Format("{0:##.##} Bytes", size);
            }
            else
            {
                return "0 Bytes";
            }
        }

        /// <summary>
        /// Converts a coordinate from the polar coordinate system to the cartesian coordinate system.
        /// </summary>
        public static Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point((int)x, (int)y);
        }

        public static Point OffsetExt(this Point point, int X, int Y)
        {
            return new Point(point.X + X, point.Y + Y);
        }

        /*********************************************************************************/
        /// <summary>
        /// Returns a string starting with 0 and ending at index value maxLength.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        /// Returns a string starting from value and ends at end of string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static string Mid(this string value, int from)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (from >= value.Length)
                return "";

            return value.Substring(from);
        }

        /// <summary>
        /// Returns a string starting from value and ends at end at number of characters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string Mid(this string value, int from, int number)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (from >= value.Length)
                return "";

            if (number < 0)
            {
                from = from - number;
                number = -number;
            }

            if ((from + number) >= value.Length)
                return value.Substring(from);

            return value.Substring(from, number);
        }




    }
}
