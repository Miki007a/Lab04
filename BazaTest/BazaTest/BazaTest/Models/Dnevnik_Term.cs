namespace BazaTest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DNEVNIK_TERM")]
    public class Dnevnik_Term
    {
        [Key]
        [Column("DT_ID")]
        public int Id { get; set; }

        [Column("DT_DATE")]
        public DateTime? DtDate { get; set; }

        [Column("DT_V_FIRMA_ID")]
        public string? DtVFirmaId { get; set; }  // Changed from int? to string?

        [Column("DT_V_CARD_ID")]
        public string? DtVCardId { get; set; }

        [Column("DT_T_ID")]
        public int? DtTId { get; set; }

        [Column("DT_T_TYPE_ID")]
        public int? DtTTypeId { get; set; }  // Changed from byte? to int?

        [Column("DT_IN_OUT")]
        public string? DtInOut { get; set; }

        [Column("DT_NASTAN_ID")]
        public int? DtNastanId { get; set; }

        [Column("DT_NASTAN_IME")]
        public string? DtNastanIme { get; set; }

        [Column("DT_F_ID")]
        public int? DtFId { get; set; }

        [Column("DT_STATUS")]
        public int? DtStatus { get; set; }  // Changed from byte? to int?

        [Column("DT_STATUS_DESC")]
        public string? DtStatusDesc { get; set; }

        [Column("DT_DATE_READ")]
        public DateTime? DtDateRead { get; set; }

        [Column("DT_TYPE")]
        public string? DtType { get; set; }  // Ensure it only has max 3 characters

        [Column("DT_USER_NAME")]
        public string? DtUserName { get; set; }

        [Column("DT_V_ID")]
        public int? DtVId { get; set; }

        [Column("DT_V_RAB_VREME_ID")]
        public short? DtVRabVremeId { get; set; }

        [Column("DT_T_IP")]
        public string? DtTIp { get; set; }

        [Column("DT_V_RAB_VREME_TIP_ID")]
        public int? DtVRabVremeTipId { get; set; }

        [Column("DT_V_RAB_VREME_SAME_DAY")]
        public int? DtVRabVremeSameDay { get; set; }

        [Column("DT_USER_ID")]
        public int? DtUserId { get; set; }

        [Column("DT_USER_DATE")]
        public DateTime? DtUserDate { get; set; }

        [Column("DT_USER_APP", TypeName = "CHAR(1)")]
        public string? DtUserApp { get; set; }  // Ensure it has max 1 character

        [Column("DT_USER_IP")]
        public string? DtUserIp { get; set; }

        [Column("DT_USER_STATION")]
        public string? DtUserStation { get; set; }

        [Column("DT_USER_ACTION")]
        public string? DtUserAction { get; set; }  // Ensure it has max 1 character

        [Column("DT_F_ID_SYSTEM")]
        public int? DtFIdSystem { get; set; }

        [Column("DT_DOOR_ID")]
        public int? DtDoorId { get; set; }
    }
}
