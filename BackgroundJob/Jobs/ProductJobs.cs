
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJob.Jobs
{
    public class ProductJobs(IEmailSender _emailSender, IAppDbContext _appDb, UserManager<ApplicationUser> _userManager)
    {
        public async Task SendProductNotification()
        {
            var users = await _userManager.Users.ToListAsync();
            var products = await _appDb.Products.Where(a => !a.UsersNotified).ToListAsync();

            foreach (var user in users)
            {
                var message = string.Join(", ", products.Select(a => a.EnName));
                 _emailSender.SendEmail(user.Email, "New Products Added", message);
            }

            foreach (var product in products)
                product.UsersNotified = true;

            await _appDb.SaveChangesAsync();
        }
    }

}
