using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SISAPI.Models;

namespace SISAPI.Controllers
{
    /// <summary>
    /// API endpoints for accessing Students
    /// </summary>
    public class StudentController : ApiController
    {

/// <summary>
/// Set Visual Studio in Debug or Release mode to change the beginning string of the api endpoint
/// </summary>
#if DEBUG
        const string apiPath = "t1";
#else
        const string apiPath = "1.0";
#endif

        //Hard coded Test Cases for Students
        Student[] students = new Student[]
        {
            new Student { first_name = "Miranda", last_name = "Keyes", username = "MKeyes", email = "MKeyes@unsc.net", school = "UNSC Navy", id_number = "15972-19891-MK", code = "UNSC", coop = true},
            new Student { first_name = "Guilty", last_name = "Spark", username = "Spark", email = "Spark@forerunner.net", school = "Monitor", id_number = "343", code = "F AI", coop = false},
            new Student { first_name = "Thel", last_name = "Vadamee", username = "TVadamee", email = "TVadamee@covenant.net", school = "Arbiter", id_number = "5", code = "Elite", coop = false}
        };

        /// <summary>
        /// Returns all students
        /// </summary>
        /// <returns>Students</returns>
        [Route(apiPath + "/students")]
        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        /// <summary>
        /// Returns all students located at specified school
        /// </summary>
        /// <param name="code">3 Character school designation</param>
        /// <returns>Students</returns>
        [Route(apiPath + "/students/{code}")]
        public IEnumerable<Student> GetAllStudentsByCode(string code)
        {
            List<Student> student = new List<Student>();
            foreach (var child in students)
            {
                if (child.code == code)
                {
                    student.Add(child);
                }
            }
            return student;
        }

        /// <summary>
        /// Returns all students located at specified school who are also in co-op
        /// </summary>
        /// <param name="code">3 Character school designation</param>
        /// <returns>Student</returns>
        [Route(apiPath + "/students/{code}/co-op")]
        public IEnumerable<Student> GetAllTeachersByCodeAndCoop(string code)
        {
            List<Student> student = new List<Student>();
            foreach (var child in students)
            {
                if (child.code == code && child.coop == true)
                {
                    student.Add(child);
                }
            }
            return student;
        }

        /// <summary>
        /// Returns all students who are in co-op
        /// </summary>
        /// <returns>Students</returns>
        [Route(apiPath + "/students/co-op")]
        public IEnumerable<Student> GetAllTeachersByCoop()
        {
            List<Student> student = new List<Student>();
            foreach (var child in students)
            {
                if (child.coop == true)
                {
                    student.Add(child);
                }
            }
            return student;
        }

        /// <summary>
        /// Returns a student by student number, email, or username
        /// </summary>
        /// <param name="id">Student Number, Email, Username</param>
        /// <returns>Student</returns>
        [Route(apiPath + "/student/{id}")]
        public IHttpActionResult GetStudent(string id)
        {
            if (id.Contains("@"))
            {
                var student = students.FirstOrDefault((p) => p.email == id);
                return Ok(student);
            }
            if (id.Any(char.IsDigit))
            {
                var student = students.FirstOrDefault((p) => p.id_number == id);
                return Ok(student);
            }
            else
            {
                var student = students.FirstOrDefault((p) => p.username == id);
                return Ok(student);
            }
        }
    }
}
