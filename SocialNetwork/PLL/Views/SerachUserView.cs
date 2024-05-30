using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.PLL.Views
{
    public class SerachUserView
    {
        FriendRepository friendRepository;
        UserService userService;
        FriendEntity friendEntity;
        public void Show()
        {
            friendRepository = new FriendRepository();
            userService = new UserService();
            friendEntity = new FriendEntity();

            Console.WriteLine("Для поиска друзе введите email друга:");
            var friendEmail = Console.ReadLine();

            if (friendEmail == null)
                throw new ArgumentNullException();
            if (userService.FindByEmail(friendEmail) == null)
                throw new UserNotFoundException();
            else
            {
                var newFriend = userService.FindByEmail(friendEmail).Id;
                friendEntity.id = newFriend;
                var newFriendEntity = friendEntity; 
                friendRepository.Create(newFriendEntity);
            }

            

        }
    }
}
