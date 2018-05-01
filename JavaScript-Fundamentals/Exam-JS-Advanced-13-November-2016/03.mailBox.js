class MailBox {
    constructor() {
        this.mailBox = [];
        this._messageCount = 0;
    }

    addMessage(subject, text) {
        let message = {
            subject: subject,
            text: text
        };

        this.mailBox.push(message);
        this._messageCount++;
        return this;
    }


    get messageCount() {
        return this._messageCount;
    }

    deleteAllMessages() {
        this.mailBox = [];
        this._messageCount = 0;
    }

    findBySubject(substr) {
        let validMessages = this.mailBox.filter(m => m.subject.includes(substr)).sort((a, b) => a-b);

        return validMessages.length > 0 ? validMessages : [];
    }

    toString() {
        if (this.mailBox.length > 0) {
            let allMessages = '';
            for (let message of this.mailBox) {
                allMessages += `* [${message.subject}] ${message.text}\n`;
            }
            return allMessages;
        } else {
            return '* (empty mailbox)';
        }
    }
}

let mb = new MailBox();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
mb.addMessage("meeting", "Let's meet at 17/11");
mb.addMessage("beer", "Wanna drink beer tomorrow?");
mb.addMessage("question", "How to solve this problem?");
mb.addMessage("Sofia next week", "I am in Sofia next week.");
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
console.log("Messages holding 'rakiya': " +
    JSON.stringify(mb.findBySubject('rakiya')));
console.log("Messages holding 'ee': " +
    JSON.stringify(mb.findBySubject('ee')));

mb.deleteAllMessages();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);

console.log("New mailbox:\n" +
    new MailBox()
        .addMessage("Subj 1", "Msg 1")
        .addMessage("Subj 2", "Msg 2")
        .addMessage("Subj 3", "Msg 3")
        .toString());