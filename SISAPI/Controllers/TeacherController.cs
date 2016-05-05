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
    /// API endpoints for accessing Teachers
    /// </summary>
    public class TeacherController : ApiController
    {

/// <summary>
/// Set Visual Studio in Debug or Release mode to change the beginning string of the api endpoint
/// </summary>
#if DEBUG
        const string apiPath = "t1";
#else
        const string apiPath = "1.0";
#endif

        //Hard coded Test Cases for Teachers
        Teacher[] teachers = new Teacher[]
        {
            new Teacher { first_name = "Master", last_name = "Chief", username = "SpartanJohn", email = "John117@unsc.net", school = "UNSC Naval Special Warfare Command", id_number = "S-117", code = "UNSC", coop = true},
            new Teacher { first_name = "UNSC AI", last_name = "Chief", username = "Cortana", email = "Cortana@unsc.net", school = "UNSC AI", id_number = "CTN 0452-9", code = "UNSC AI", coop = false},
            new Teacher { first_name = "Avery", last_name = "Johnson", username = "AJohnson", email = "AJohnson@unsc.net", school = "UNSC Marine Corps", id_number = "48789-20114-AJ", code = "UNSC", coop = true}
        };

        /// <summary>
        /// Returns all teachers
        /// </summary>
        /// <returns>Teachers</returns>
        [Route(apiPath + "/teachers")]
        [BasicHttpAuthorize]
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return teachers;
        }

        /// <summary>
        /// Returns all teachers located at specified school
        /// </summary>
        /// <param name="code">3 Character school designation</param>
        /// <returns>Teachers</returns>
        [Route(apiPath + "/teachers/{code}")]
        public IEnumerable<Teacher> GetAllTeachersByCode(string code)
        {
            List<Teacher> teacher = new List<Teacher>();
            foreach(var teach in teachers)
            {
                if(teach.code == code)
                {
                    teacher.Add(teach);
                }
            }
            return teacher;
        }

        /// <summary>
        /// Returns all teachers located at specified school who are also in co-op
        /// </summary>
        /// <param name="code">3 Character school designation</param>
        /// <returns>Teachers</returns>
        [Route(apiPath + "/teachers/{code}/co-op")]
        public IEnumerable<Teacher> GetAllTeachersByCodeAndCoop(string code)
        {
            List<Teacher> teacher = new List<Teacher>();
            foreach (var teach in teachers)
            {
                if (teach.code == code && teach.coop == true)
                {
                    teacher.Add(teach);
                }
            }
            return teacher;
        }

        /// <summary>
        /// Returns all teachers who are in co-op
        /// </summary>
        /// <returns>Teachers</returns>
        [Route(apiPath + "/teachers/co-op")]
        public IEnumerable<Teacher> GetAllTeachersByCoop()
        {
            List<Teacher> teacher = new List<Teacher>();
            foreach (var teach in teachers)
            {
                if (teach.coop == true)
                {
                    teacher.Add(teach);
                }
            }
            return teacher;
        }

        /// This was the first /teacher/{id} endpoint but in swagger the Model Schema wasn't generating
        /// I like the code more for this but documentation wasn't working, switched it to IEnumerable instead of
        /// IHttpActionResult and Swagger UI was able to generate the Model Schema section.
        /// Interesting....
        /// <summary>
        /// Returns a teacher by EIN, email, or username
        /// </summary>
        /// <param name="id">EIN, Email, Username</param>
        /// <returns>Teacher</returns>
        /*
        [Route(apiPath + "/teacher/{id}")]
        public IHttpActionResult GetTeacher(string id)
        {
            if(id.Contains("@"))
            {
                var teacher = teachers.FirstOrDefault((p) => p.email == id);
                return Ok(teacher);
            }
            if (id.Any(char.IsDigit))
            {
                var teacher = teachers.FirstOrDefault((p) => p.id_number == id);
                return Ok(teacher);
            }
            else
            {
                var teacher = teachers.FirstOrDefault((p) => p.username == id);
                return Ok(teacher);
            }
        }
        */

        /// <summary>
        /// Returns a teacher by EIN, email, or username
        /// </summary>
        /// <param name="id">EIN, Email, Username</param>
        /// <returns>Teacher</returns>
        [Route(apiPath + "/teacher/{id}")]
        public IEnumerable<Teacher> GetTeacher(string id)
        {
            List<Teacher> teacher = new List<Teacher>();
            if (id.Contains("@"))
            {
                foreach (var teach in teachers)
                {
                    if (teach.email == id)
                    {
                        teacher.Add(teach);
                        return teacher;
                    }
                }
            }
            if (id.Any(char.IsDigit))
            {
                foreach (var teach in teachers)
                {
                    if (teach.id_number == id)
                    {
                        teacher.Add(teach);
                        return teacher;
                    }
                }
            }
            else
            {
                foreach (var teach in teachers)
                {
                    if (teach.username == id)
                    {
                        teacher.Add(teach);
                        return teacher;
                    }
                }
            }
            return null;
        }

    }
}
