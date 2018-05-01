function addItem() {
    let textElement = document.getElementById('newItemText').value;
    let valueElement = document.getElementById('newItemValue').value;

    let option = document.createElement('option');
    option.textContent = textElement;
    option.value = valueElement;

    let select = document.getElementById('menu');
    select.appendChild(option);

    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}