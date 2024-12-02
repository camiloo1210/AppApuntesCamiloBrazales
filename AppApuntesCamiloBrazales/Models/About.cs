using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamiloBrazales.Models
{
    class About
    {
		public string Title => "Camilo Brazales";
		public string Version => AppInfo.VersionString;
		public string MoreInfoUrl => "https://aka.ms/maui";
		public string Message => "Mi nombre es Camilo tengo 20 años y me gusta jugar valorant";
		public string Image => "onepiecee.jpg";

	}
}
