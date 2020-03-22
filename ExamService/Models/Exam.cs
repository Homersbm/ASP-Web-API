using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ExamService.Models
{
    public class Exam
    {
        /// <summary>
        /// ExamKey Unique
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExamKey { get; set; }

        /// <summary>
        /// Patinet Key from Patinet Data
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string PatientKey { get; set; }

        /// <summary>
        /// Tells if Exam is Locked or not
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Exam Status C:Create U: Update 
        /// </summary>
        public string ExamStatusCode { get; set; }

        /// <summary>
        /// Patinet SEX
        /// </summary>
        public string PatientSexCode { get; set; }

        /// <summary>
        /// Exam Age in string
        /// </summary>
        public string ExamAge { get; set; }
    }
}
