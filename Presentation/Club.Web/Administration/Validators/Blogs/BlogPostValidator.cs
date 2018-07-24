using FluentValidation;
using Club.Admin.Models.Blogs;
using Club.Core.Domain.Blogs;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Blogs
{
    public partial class BlogPostValidator : BaseSiteValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Title.Required"));

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Body.Required"));

            //blog tags should not contain dots
            //current implementation does not support it because it can be handled as file extension
            RuleFor(x => x.Tags)
                .Must(x => x == null || !x.Contains("."))
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Tags.NoDots"));

            SetDatabaseValidationRules<BlogPost>(dbContext);

        }
    }
}