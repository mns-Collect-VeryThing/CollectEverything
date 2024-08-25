using FluentValidation;

namespace CollectEverything.Product.Articles.DTOs.Input
{
    public class CreateArticleDtoValidator : AbstractValidator<CreateArticleDto>
    {
        public CreateArticleDtoValidator()
        {
            RuleFor(dto => dto.Prix)
                .InclusiveBetween(ProductConsts.ArticleMinimumPrice, ProductConsts.ArticleMaximumPrice);
            RuleFor(dto => dto.Quantity)
                .InclusiveBetween(ProductConsts.ArticleMinimumQuantity, ProductConsts.ArticleMaximumQuantity);
        }
    }
}