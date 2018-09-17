using System.Collections.Generic;

namespace WebApp.Model
{
    public class UserViewModel: BaseViewModel
    {
        public List<RoleViewModel> roles { get; set; }
    }
}
