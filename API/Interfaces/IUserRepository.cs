using API.DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
	public interface IUserRepository
	{
		void Update(AppUser user); //To Update profile

		Task<Boolean> SaveAllAsync(); //to save all our changes

		Task<IEnumerable<AppUser>> GetUsersAsync();
		Task<AppUser> GetUserByIdAsync(int id);
		Task<AppUser> GetUserByUsernameAsync(string username);
		Task<IEnumerable<MemberDto>> GetMembersAsync();
		Task<MemberDto> GetMemberAsync(string username);

	}
}
