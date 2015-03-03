﻿using System;
using System.Collections.Generic;
using AspSixApp.Models;
using Microsoft.AspNet.Identity;

namespace AspSixApp.CustomIdentity
{
    internal class InMemoryUserProvider : UserProvider<IndividualUser>
    {
        public InMemoryUserProvider()
        {
            users = new List<IndividualUser>();
        }
        public override IEnumerator<IndividualUser> GetEnumerator() => users.GetEnumerator();

        public override IdentityResult Add(IndividualUser user) =>
            WithLock(() =>
            {
                if (!users.Contains(user))
                {
                    users.Add(user);
                    return IdentityResult.Success;
                }
                else
                {
                    return IdentityResult.Failed();
                }
            });

        public override IdentityResult Delete(IndividualUser user) =>
            WithLock(() => users.Remove(user) ? IdentityResult.Success : IdentityResult.Failed());

        public override IdentityResult Update(IndividualUser user) =>
            WithLock(() =>
            {
                var existing = this[user.Id];
                if (existing == null)
                {
                    return IdentityResult.Failed();
                }
                else
                {   // Transfer all properties except UserId, UserName,
                    existing.AccessFailedCount = user.AccessFailedCount;
                    existing.ConcurrencyStamp = user.ConcurrencyStamp;
                    existing.NormalizedUserName = user.NormalizedUserName;
                    existing.Email = user.Email;
                    existing.EmailConfirmed = user.EmailConfirmed;
                    existing.FirstName = user.FirstName;
                    existing.LastName = user.LastName;
                    existing.LockoutEnabled = user.LockoutEnabled;
                    existing.LockoutEnd = user.LockoutEnd;
                    existing.NormalizedEmail = user.NormalizedEmail;
                    existing.PasswordHash = user.PasswordHash;
                    existing.PhoneNumber = user.PhoneNumber;
                    existing.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                    existing.Projects = user.Projects;
                    existing.SecurityStamp = user.SecurityStamp;
                    existing.TwoFactorEnabled = user.TwoFactorEnabled;
                    return IdentityResult.Success;
                }
            });
        public override IndividualUser this[string id] => WithLock(() => users.Find(u => u.Id == id));

        private readonly List<IndividualUser> users;

        private   T WithLock<T>(Func<T> f)
        {
            lock (lockon)
            {
                return f();
            }
        }
        private readonly object lockon = new object();
    }
}