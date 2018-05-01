class SortedList {
    constructor(){
        this.internalArray = [];
        this.size = 0;
    }

    add(element) {
        this.internalArray.push(element);
        this.size++;
        this.sort();
    }

    remove(index) {
        if (index >= 0 && index < this.internalArray.length) {
            this.internalArray.splice(index, 1);
            this.size--;
        }
    }

    get(index) {
        if (index >= 0 && index < this.internalArray.length) {
            return this.internalArray[index];
        }
    }

    sort() {
        this.internalArray = this.internalArray.sort((a, b) => a - b);
    }

    toString() {
        return this.internalArray.join(' ');
    }
}

let sortedList = new SortedList();
sortedList.add(5);
sortedList.add(6);
sortedList.remove(0);
sortedList.get(-1);
sortedList.size;