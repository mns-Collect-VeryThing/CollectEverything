using FluentValidation;

namespace CollectEverything.Product.Articles.DTOs.Input
{
    public class UpdateArticleDtoValidator : AbstractValidator<UpdateArticleDto>
    {
        public UpdateArticleDtoValidator()
        {
            RuleFor(dto => dto.Prix)
                .InclusiveBetween(ProductConsts.ArticleMinimumPrice, ProductConsts.ArticleMaximumPrice);
            RuleFor(dto => dto.Quantity)
                .InclusiveBetween(ProductConsts.ArticleMinimumQuantity, ProductConsts.ArticleMaximumQuantity);
            ;
        }
    }
}