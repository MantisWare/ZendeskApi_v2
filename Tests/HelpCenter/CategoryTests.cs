﻿using NUnit.Framework;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.HelpCenter.Categories;

namespace Tests.HelpCenter
{
   [TestFixture]
   public class CategoryTests
   {
      private ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

      [Test]
      public void CanGetCategories()
      {
         var res = api.HelpCenterApi.Categories.GetCategories();
         Assert.Greater(res.Count, 0);

         var res1 = api.HelpCenterApi.Categories.GetCategoryById(res.Categories[0].Id.Value);
         Assert.AreEqual(res1.Category.Id, res.Categories[0].Id);
      }

      [Test]
      public void CanCreateUpdateAndDeleteCategories()
      {
         var res = api.HelpCenterApi.Categories.CreateCategory(new Category()
         {
            Name = "My Test category"
         });
         Assert.Greater(res.Category.Id, 0);

         res.Category.Description = "updated description";
         var update = api.HelpCenterApi.Categories.UpdateCategory(res.Category);
         Assert.AreEqual(update.Category.Description, res.Category.Description);

         Assert.True(api.HelpCenterApi.Categories.DeleteCategory(res.Category.Id.Value));
      }
   }
}