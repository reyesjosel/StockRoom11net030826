using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Keyless]
[Table("Table_Address_Book")]
public partial class Table_Address_Book
{
    [Column(TypeName = "varchar(255)")]
    public string Index { get; set; } = null!;

    [Column(TypeName = "INT")]
    public int ID { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? NAME { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? PNAME { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? ADDRESS { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? CITY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? STATE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? ZIP { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? COUNTRY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? PHONE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? EXTENSION { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? TYPE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? DATE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? ACCOUNT { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? TERMS { get; set; }

    [Column(TypeName = "INT")]
    public int? DISCOUNT { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? FAXNO { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? COMMENT { get; set; }

    [Column(TypeName = "INT")]
    public int? TAXR { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? RESALE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SALESMAN { get; set; }

    [Column(TypeName = "INT")]
    public int? CURBAL { get; set; }

    [Column(TypeName = "INT")]
    public int? CREDLIM { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? TERRITORY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? REGION { get; set; }

    [Column(TypeName = "INT")]
    public int? YR_QUOTA { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? CONTRACT { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SERIAL { get; set; }

    [Column(TypeName = "INT")]
    public int? SALESLEVEL { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? COUNTY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? TAX_CODE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? E_MAIL { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? LASTACCESS { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BNAME { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BPNAME { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BADDRESS { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BCITY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BSTATE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BZIP { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BCOUNTRY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BPHONE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SNAME { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SPNAME { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SADDRESS { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SCITY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SSTATE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SZIP { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SCOUNTRY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SPHONE { get; set; }

    [Column(TypeName = "INT")]
    public int? COMMISS { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? CONTACT { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? TITLE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SALUTE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? REFDBYTXT { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? LEADSOURCE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? PURPOSE { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? PRIORITY { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? CONCERN { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? INTEREST { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SALE_EMAIL { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? CRDT_CARD { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? CCARDEXP { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? DACCT1 { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? STATUS { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? TAXID { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? FORM1099 { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? PRICEKEYS { get; set; }

    [Column(TypeName = "INT")]
    public int? DIVISION { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? QBCUSTID { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? QBVENDID { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? NOFAX { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? NOEMAIL { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? NOCALL { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? ADDRESS2 { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? BADDRESS2 { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SADDRESS2 { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? URL { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SHIPVIA { get; set; }
}
