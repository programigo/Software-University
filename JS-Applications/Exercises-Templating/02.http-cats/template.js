$(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        let source = await $.get('catTemplate.hbs');
        let template = Handlebars.compile(source);
        let data = window.cats;
        let context = {
            cats: data
        };
        let html = template(context);
        $('#allCats').html(html);
        attachEvents();
    }

    function attachEvents() {
        $('.btn-primary').on('click', async function () {
            let parent = $(this.parentNode.children[1]);
            if (this.textContent === 'Show status code') {
                this.textContent = 'Hide status code';
                parent.toggle();
            } else {
                this.textContent = 'Show status code';
                parent.toggle();
            }
        })
    }
});
