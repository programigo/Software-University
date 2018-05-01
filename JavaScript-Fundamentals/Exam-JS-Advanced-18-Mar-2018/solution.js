class PaymentManager {
    constructor(title) {
        this.title = title;
        this.element = this.createElement();
    }

    render(id) {
        let container = $(`#${id}`);
        container.append(this.element);
    }

    createElement() {
        let table = $('<table>');
        let caption = $(`<caption>${this.title} Payment Manager</caption>`);
        let tableHead = $('<thead>');
        let tableRow = $('<tr>');
        let nameTh = $('<th class="name">Name</th>');
        let categoryTh = $('<th class="category">Category</th>');
        let priceTh = $('<th class="price">Price</th>');
        let actions = $('<th>Actions</th>');
        tableRow.append(nameTh);
        tableRow.append(categoryTh);
        tableRow.append(priceTh);
        tableRow.append(actions);
        tableHead.append(tableRow);
        table.append(caption);
        table.append(tableHead);

        let tableBody = $('<tbody class="payments">');
        table.append(tableBody);

        let tableFooter = $('<tfoot class="input-data">');
        let footerRow = $('<tr>');
        let nameInputField = $('<td><input name="name" type="text"></td>');
        let categoryInputField = $('<td><input name="category" type="text"></td>');
        let priceInputField = $('<td><input name="price" type="number"></td>');
        let addButton = $('<td><button>Add</button></td>');
        addButton.on('click', () => {
            if (nameInputField.children(0).val() != '' && categoryInputField.children(0).val() != '' && priceInputField.children(0).val() != '') {
                let bodyTableRow = $(`<tr>`);
                let paymentName = $(`<td>${nameInputField.children(0).val()}</td>`);
                let paymentCategory = $(`<td>${categoryInputField.children(0).val()}</td>`);
                let paymentPrice = $(`<td>${Number(priceInputField.children(0).val())}</td>`);
                let deleteButton = $('<td><button>Delete</button></td>');
                deleteButton.on('click', function () {
                    bodyTableRow.remove();
                });
                nameInputField.children(0).val('');
                categoryInputField.children(0).val('');
                priceInputField.children(0).val('');

                bodyTableRow.append(paymentName);
                bodyTableRow.append(paymentCategory);
                bodyTableRow.append(paymentPrice);
                bodyTableRow.append(deleteButton);
                tableBody.append(bodyTableRow);
            }
        });
        footerRow.append(nameInputField);
        footerRow.append(categoryInputField);
        footerRow.append(priceInputField);
        footerRow.append(addButton);
        tableFooter.append(footerRow);
        table.append(tableFooter);

        return table;
    }
}