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
    /// API endpoints for accessing Schools
    /// </summary>
    public class SchoolController : ApiController
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
        School[] schools = new School[]
        {
            new School { id = "abe", domain = "abe.wrdsb.ca", email = "abe@wrdsb.on.ca", name = "Abraham Erb Public School", 
                street_address = "710 Laurelwood Dr.", city = "Waterloo", postal_code = "N2M 2G3", phone = "519 745 7312",
                maps_url = "http =//maps.google.com/maps?f=q&hl=en&q=710%20Laurelwood%20Dr+Waterloo+Ontario", panel = "elementary",
                school_day = true}
        };

        /// <summary>
        /// Returns all schools
        /// </summary>
        /// <returns>Schools</returns>
        [Route(apiPath + "/schools")]
        public IEnumerable<School> GetAllSchools()
        {
            return schools;
        }

        /// <summary>
        /// Return school information for a provided school code
        /// </summary>
        /// <param name="code">3 Character school designation</param>
        /// <returns>School</returns>
        [Route(apiPath + "/schools/{code}")]
        public IEnumerable<School> GetSchoolByCode(string code)
        {
            List<School> school = new List<School>();
            foreach (var location in schools)
            {
                if (location.id == code)
                {
                    school.Add(location);
                }
            }
            return school;
        }
    }
}
