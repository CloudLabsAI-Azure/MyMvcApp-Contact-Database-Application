using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class UserController : Controller
    {
        // Simulating a database with an in-memory list of users
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            // Display the list of all users
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user with the given ID
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Display the form for creating a new user
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Add the new user to the list
                user.Id = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1; // Assign a unique ID
                userlist.Add(user);
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, show the form again
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user with the given ID
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                // Find the existing user and update their details
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);
                if (existingUser == null)
                {
                    return NotFound(); // Return 404 if user not found
                }

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                return RedirectToAction(nameof(Index));
            }

            // If validation fails, show the form again
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user with the given ID
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the user and remove them from the list
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                userlist.Remove(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
