using System;
namespace identityServer.db
{
	public interface IAuthRepository
	{
		User GetUserById(string id);
		User GetUserByUsername(string username);
		bool ValidatePassword(string username, string plainTextPassword);
	}
}
