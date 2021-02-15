using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Application.Services.DtoModels
{
    public class EmployeeDto
    {

        public EmployeeDto(int companyId, DateTime createdOn, DateTime deletedOn, string email, string fax, string name, DateTime lastLogin, 
            string password,int portalId, int roleId, int statusId, string telephone, DateTime updatedOn, string username)
        {
            CompanyId = companyId;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            Email = email;
            Fax = fax;
            Name = name;
            LastLogin = lastLogin;
            Password = password;
            PortalId = portalId;
            RoleId = roleId;
            StatusId = statusId;
            Telephone = telephone;
            UpdatedOn = updatedOn;
            Username = username;
        }


        [JsonProperty("CompanyId")]
        public int CompanyId { get; set; }

        [JsonProperty("CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("DeletedOn")]
        public DateTime DeletedOn { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Fax")]
        public string Fax { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LastLogin")]
        public DateTime LastLogin { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("PortalId")]
        public int PortalId { get; set; }

        [JsonProperty("RoleId")]
        public int RoleId { get; set; }

        [JsonProperty("StatusId")]
        public int StatusId { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [JsonProperty("UpdatedOn")]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }
    }
}
