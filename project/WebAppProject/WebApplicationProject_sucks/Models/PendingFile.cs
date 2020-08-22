using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{//note: We created a seperate table for other files to maintain the context
    //once a pending user is accpeted, files are removed, while keeping integerity 
    //optimizining space usage 
    public class PendingFile
    {
        [Key]
        public int FileID { set; get; }

        public byte[] FileContent { set; get; }

        //reference to its uploader
        [ForeignKey("ProfessionalPending")]
        public string P_UserName { get; set; }
        public ProfessionalPending ProfessionalPending { get; set; }


        public PendingFile(int FileId, byte[] FileContent, string pendingUser)
        {
            this.FileID = FileId;
            this.FileContent = FileContent;
            this.P_UserName = pendingUser;
        }

    }

}