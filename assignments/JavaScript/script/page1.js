async function getPosts() {

    await fetch("https://jsonplaceholder.typicode.com/posts").then(function (response) {

        return response.json();
    }).then(function (data) {
        let tbody = document.querySelector("#tblBody");
        tbody.innerHTML = "";
        let length = data.length;
        for (let i = 0; i < length; i++) {
            let tr = `<tr><td>${data[i].id}</td><td>${data[i].title}</td><td>${data[i].body}</td></tr>`
            tbody.innerHTML = tbody.innerHTML + tr;
        }
    })
}


async function getAlbums() {

    await fetch("https://jsonplaceholder.typicode.com/albums").then(function (response) {

        return response.json();

    }).then(function (data) {
        let tbody = document.querySelector("#tblAlbum");
        tbody.innerHTML = "";
        let length = data.length;
        for (let i = 0; i < length; i++) {
            let tr = `<tr><td><a href="http://localhost:5500/typora/antra/assignments/JavaScript/page2.html#${data[i].userId}">${data[i].userId}</a></td><td>${data[i].id}</td><td>${data[i].title}</td></tr>`

            tbody.innerHTML = tbody.innerHTML + tr;
        }
    })

}


getPosts()

getAlbums()
