using ExamService.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ExamService.Repository
{
    public class ExamRepository
    {
        private readonly IMongoCollection<Exam> exam;
        public ExamRepository(IExamCURDDatabaseSettings settings)
        {
            Console.WriteLine("ExamRepository constructor");
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            exam = database.GetCollection<Exam>(settings.ExamCollectionName);
        }


        public List<Exam> Get() =>
           exam.Find(ex => true).ToList();

        public Exam Get(string examkey) =>
            exam.Find<Exam>(ex => ex.ExamKey == examkey).FirstOrDefault();

        public Exam Create(Exam ex)
        {
            exam.InsertOne(ex);
            return ex;
        }

        public void Update(string examKey, Exam _exam) =>
            exam.ReplaceOne(ex => ex.ExamKey == examKey, _exam);

        public void Remove(Exam _exam) =>
            exam.DeleteOne(exm => exm.ExamKey == _exam.ExamKey);

        public void Remove(string examKey) =>
            exam.DeleteOne(ex => ex.ExamKey == examKey);
    }
}
