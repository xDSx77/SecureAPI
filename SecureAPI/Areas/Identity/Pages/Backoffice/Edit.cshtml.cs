using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureAPI.Models;

namespace SecureAPI.Areas.Identity.Pages.Backoffice
{
    public class EditModel : PageModel
    {
        public static IdentityRole Role { get; set; }
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public List<string> addUser { get; set; }

        [BindProperty]
        public List<string> removeUser { get; set; }

        public EditModel(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        
        public async Task OnGet(string id)
        {
            Role = await _roleManager.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            foreach (var userId in addUser)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                if (user != null && Role != null)
                    await _userManager.AddToRoleAsync(user, Role.Name);
            }
            foreach (var userId in removeUser)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                if (user != null && Role != null)
                    await _userManager.RemoveFromRoleAsync(user, Role.Name);
            }
            return Page();
        }
    }
}
