using BtlWebForm.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BtlWebForm.Repository
{
    public class UserRepository
    {
        FileIO fileIO = new FileIO();
        public List<UserEntity> FindAllUser()
        {
            string listUseJson = fileIO.ReadFileJson(Constant.DATA_USERS);
            if (listUseJson != null)
            {
                List<UserEntity> users = JsonConvert.DeserializeObject<List<UserEntity>>(listUseJson);
                return users;
            }
            return null;
        }

        public UserEntity FindUserByUsername(string username)
        {
            List<UserEntity> users = FindAllUser();
            if (users == null)
                return null;
            foreach (UserEntity user in users)
            {
                if (user.Username.Equals(username))
                    return user;
            }
            return null;
        }

        public UserEntity FindUserByID(int ID)
        {
            List<UserEntity> users = FindAllUser();
            if (users == null)
                return null;
            foreach (UserEntity user in users)
            {
                if (user.ID == ID)
                    return user;
            }
            return null;
        }

        public bool SaveUser(UserEntity user)
        {
            // đọc list user ra
            List<UserEntity> users = FindAllUser();
            if (users == null)
                users = new List<UserEntity>();

            users.Add(user);

            if (SaveListUsers(users))
                return true;
            return false;
        }

        public bool SaveListUsers(List<UserEntity> users)
        {
            string userToJson = JsonConvert.SerializeObject(users);
            if (fileIO.WriteFileJson(Constant.DATA_USERS, userToJson))
                return true;
            else
                return false;
        }

        public bool ChangeInfoUser(UserEntity userChange)
        {
            List<UserEntity> users = FindAllUser();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username.Equals(userChange.Username))
                {
                    users[i] = userChange;
                }
            }
            if (SaveListUsers(users))
                return true;
            else
                return false;
        }
    }

}