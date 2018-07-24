using FluentValidation;
using Club.Services.Localization;
using Club.Web.Framework.Validators;
using Club.Web.Models.Blogs;

namespace Club.Web.Validators.Blogs
{
    public partial class BlogPostValidator : BaseSiteValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.AddNewComment.CommentText).NotEmpty().WithMessage(localizationService.GetResource("Blog.Comments.CommentText.Required")).When(x => x.AddNewComment != null);
        }
    }
}