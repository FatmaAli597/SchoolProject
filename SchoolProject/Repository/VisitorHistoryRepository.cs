using JsonBasedLocalization.Api.Dtos;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class VisitorHistoryRepository
    {
        Context context;
        //Visitor_HistoryDTo Visitor_HistoryDTo=new Visitor_HistoryDTo();
        VistorHitory VistorHitory = new VistorHitory();
        public VisitorHistoryRepository(Context _context)
        {
            context = _context;
        }
        public int insert(Visitor_HistoryDTo Visitor_HistoryDTo)
        {
            VistorHitory.Visit_Date= Visitor_HistoryDTo.Visit_Date;
            VistorHitory.VisitiorReason=Visitor_HistoryDTo.VisitiorReason;
           // VistorHitory.ApplicationUser.Receptionist.UserName = Visitor_HistoryDTo.Receptionist_Name;
            VistorHitory.ApplicationUser.UserName = Visitor_HistoryDTo.Receptionist_Name;
            VistorHitory.Comment=Visitor_HistoryDTo.Comment;
            context.vistorHitories.Add(VistorHitory);
            return context.SaveChanges();
            

        }

    }
}
