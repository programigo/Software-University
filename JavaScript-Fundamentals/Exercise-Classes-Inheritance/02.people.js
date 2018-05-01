function employeeHierarchy() {
    class Employee {
        constructor(name, age) {
            if (new.target === Employee) {
                throw new Error('Cannot instantiate directly.');
            }
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let currentTask = this.tasks.shift();
            console.log(this.name + currentTask);
            this.tasks.push(currentTask);
        }

        collectSalary() {
            return `${this.name} received`;
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [` is working on a simple task.`];
        }

        collectSalary() {
            console.log(`${super.collectSalary()} ${this.salary} this month.`);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [` is working on a complicated task.`,
                ` is taking time off work.`,
                ` is supervising junior workers.`];
        }

        collectSalary() {
            console.log(`${super.collectSalary()} ${this.salary} this month.`);
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [` scheduled a meeting.`,
                ` is preparing a quarterly report.`];
            this.dividend = 0;
        }

        collectSalary() {
            console.log(`${super.collectSalary()} ${this.salary + this.dividend} this month.`);
        }
    }

    return {Employee, Junior, Senior, Manager};
}

result = employeeHierarchy();

let guy2 = new result.Manager('petkan', 24);
guy2.work();
guy2.work();
guy2.work();
guy2.work();
guy2.work();
guy2.work();
