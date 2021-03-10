// data structure: array
// FIFO.
// queue constructor
// key operations:
// enqueue() -- push to tail
// dequeue()  -- pop the head
// peek()  -- peek the tail
// length()


function Queue() {
    let storage = [],
        head = 0,
        tail = 0;
    let length = 0;

    this.enqueue = function (item) {
        storage[tail++] = item;
        length++;
    }

    this.dequeue = function () {
        if (length <= 0) {
            return undefined;
        }
        delete storage[head++];   //remove first element
        length--;
        console.log(length)
    }

    this.peek = function () {
        console.log(storage[length - 1])
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



