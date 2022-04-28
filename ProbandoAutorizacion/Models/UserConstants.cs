using System.Collections.Generic;

namespace ProbandoAutorizacion.Models
{
    public class UserConstants
    {
        public static List<User> users = new List<User>()
        {
            new User{Username="Sebastian",EmailAdress="seba.zonta@gmail.com",
                Password="1234",GivenName="seba",Surname="Zonta",Role="Administrator" },
            new User{Username="NickCha",EmailAdress="nick.chapsas@gmail.com",
                Password="nick1234",GivenName="nick", Surname="Chapsas",Role="User"}
        };
    }
}
