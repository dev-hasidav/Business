using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsOdooNet6Client.Models
{
	internal class ProgramSettings
	{
		public string? Host { get; set; }
		public int Port { get; set; }
		public bool IsSSL { get; set; }
		public string? Database { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
	}
}
