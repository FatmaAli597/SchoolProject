using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonBasedLocalization.Api.Dtos
{
    public class Visitor_HistoryDTo
    {
        public int Id { get; set; }
        public DateTime Visit_Date { get; set; }
        public string VisitiorReason { get; set; }
        public string Comment { get; set; }
        public string Visitor_Name { get; set; }
        public string Receptionist_Name { get; set; }
        public string ApplicationUserID { get; set; }
        public string VisitiorId { get; set; }
    


    }
}