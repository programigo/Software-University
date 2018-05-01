function createBook(selector, title, author, isbn) {
    let wrapperDiv = $(selector);

    let bookGenerator = (function () {
      let id = 1;
      return function (selector, title, author, isbn) {
          let div = $(`<div id="book${id}" style="border: medium none;"></div>`);
          let titleParagraph = $(`<p class="title">${title}</p>`);
          let authorParagraph = $(`<p class="author">${author}</p>`);
          let isbnParagraph = $(`<p class="isbn">${isbn}</p>`);
          let selectButton = $('<button>Select</button>');
          let deselectButton = $('<button>Deselect</button>');

          selectButton.on('click', function () {
              div.css("border", "2px solid blue");
          });

          deselectButton.on('click', function () {
              div.css("border", '');
          });

          div.append(titleParagraph);
          div.append(authorParagraph);
          div.append(isbnParagraph);
          div.append(selectButton);
          div.append(' ');
          div.append(deselectButton);
          wrapperDiv.append(div);

          id++;
      }
    }());

    bookGenerator(wrapperDiv, title, author, isbn);
}