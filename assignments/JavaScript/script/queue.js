// data structure: array
// FIFO.
// queue constructor
// key operations:
// enqueue() -- push to tail
// dequeue()  -- pop the head
// peek()  -- peek the tail
// length()


function Queue() {
    this.length = 0;
    let storage = [],
        head = 0,
        tail = 0;


    this.enqueue = function (item) {
        storage[tail++] = item;
        this.length++;
    }

    this.dequeue = function () {
        if (this.length <= 0) {
            return undefined;
        }
        delete storage[head++];   //remove first element
        this.length--;
        console.log(this.length)
    }

    this.peek = function () {
        console.log(storage[this.length - 1])
    }

    this.print = function () {
        console.log(storage)
    }
}

let q = new Queue();
q.enqueue("Maria")
q.enqueue("Rodger")
q.enqueue("Amy")


q.print()

q.peek()

q.dequeue()


q.print()

console.log(q)



