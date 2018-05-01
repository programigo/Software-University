function increment(wrapper) {
    let container = $(wrapper);
    let textArea = $('<textarea class="counter" disabled="disabled">0</textarea>');
    let incrementBtn = $('<button class="btn" id="incrementBtn">Increment</button>');
    let addBtn = $('<button class="btn" id="addBtn">Add</button>');
    let list = $('<ul class="results"></ul>');

    textArea.appendTo(container);
    incrementBtn.appendTo(container);
    addBtn.appendTo(container);
    list.appendTo(container);

    incrementBtn.on('click', function () {
        textArea.val(+textArea.val() + 1);
    });

    addBtn.on('click', function () {
        let li = $(`<li>${textArea.val()}</li>`);
        li.appendTo(list);
    });
}