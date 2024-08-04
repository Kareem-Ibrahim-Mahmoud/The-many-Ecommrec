using E_commrec.Models;
using E_commrec.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commrec.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> usermanger;
        SignInManager<ApplicationUser> signmanger;
        public AccountController(UserManager<ApplicationUser> _usermanger,SignInManager<ApplicationUser> _signmanger)
        {
            usermanger = _usermanger;
            signmanger = _signmanger;

        }


        //open
        //link 
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(RegisterAccountviewmodel account)
        {

         
                if (ModelState.IsValid == true)
                {
 
                      ApplicationUser user = new ApplicationUser();
                    user.Email = account.Email;
                    user.UserName = account.UserName;
                    user.PhoneNumber = account.PhoneNumber;


                    var result = await usermanger.CreateAsync(user, account.Password);


                    if (result.Succeeded)
                    {
                        await signmanger.SignInAsync(user, false);
                        //هنا المفروض احط الكنترولير الي هيروح عليه بعد ما يعمل ريجيستر
                        return RedirectToAction("Add", "Shopping");


                    }
                

                else

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                
                return RedirectToAction("Index","Home");
               
                }
          

            return View(account);

        }

        //---------openLogin//

        public IActionResult login()
        {
            return View();

        }
        [HttpPost]
       // "~ ShoppingController/viewproduct"
        public async Task <IActionResult> login(Loginviewmodel loginUser,string? ReturnURL= null)
        {
            if(ModelState.IsValid == true)
            {
                ApplicationUser user = await usermanger.FindByEmailAsync(loginUser.Username);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signmanger.PasswordSignInAsync(user, loginUser.Password, loginUser.preseste,false);

                    if (result.Succeeded)
                    {
                        //هنا المفروض احط الكنترولير الي هيروح عليه بعد ما يعمل ريجيستر

                        return RedirectToAction("Add", "Shopping");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName and Password");

                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName and Password");

                }

            }




            return View(loginUser);

        }


        public async Task<IActionResult> logout()
        {
            await signmanger.SignOutAsync();
            return RedirectToAction("login", "Account");
        }








        public IActionResult Index()
        {
            return View();
        }
    }
}
