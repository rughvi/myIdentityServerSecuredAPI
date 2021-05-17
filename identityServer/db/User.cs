﻿using System;
using System.ComponentModel.DataAnnotations;

namespace identityServer.db
{
	public class User
	{
		[Key]
		public string Id { get; set; }
		public string Email { get; set; }
		public bool Active { get; set; }
		public string Password { get; set; }
	}
}
