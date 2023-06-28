using AulersWebAPI.DTOs;
using AulersWebAPI.Models;

namespace AulersWebAPI.Utilities.Mappers
{
    public static class UserMapper
    {
        public static UserDTO MapFromUserToUserDTO(this User user)
        {
            var userDTO = new UserDTO()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserItemPreselected = user.UserItemPreselected
            };

            return userDTO;
        }

        public static User MapFromUserCreationDTOToUser(this UserCreationDTO userCreationDTO)
        {
            var user = new User()
            {
                Name = userCreationDTO.Name,
                Email = userCreationDTO.Email,
                Surname = userCreationDTO.Surname,
                Password = userCreationDTO.Password
                //this is not how the password should be passed,
                //it needs an encryption process that remains to be done
            };

            return user;
        }
    }
}
