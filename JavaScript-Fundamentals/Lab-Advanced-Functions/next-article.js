function getArticleGenerator(articles) {
    let contentDiv = $('#content');

    return function () {
        if (articles.length > 0){
            let article = $('<article>');
            article.append(`<p>${articles.shift()}</p>`);
            contentDiv.append(article);
        }
    }
}