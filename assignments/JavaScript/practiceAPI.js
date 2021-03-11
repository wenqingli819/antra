async function getUsers() {

    await fetch("https://jsonplaceholder.typicode.com/users")
        .then(function (response) {

            return response.json();
        }).then(function (data) {
            let tbody = document.querySelector("#tbBody");
            tbody.innerHTML = "";
            let length = data.length;
            for (let i = 0; i < length; i++) {
                let row = `<tr><td>${data[i].id}</td><td>${data[i].name}</td><td>${data[i].username}</td><td>${data[i].email}</td><td>${data[i].address.street},${data[i].address.suite},${data[i].address.city}</td><td>${data[i].address.zipcode}</td><td>${data[i].address.geo.lat}</td><td>${data[i].address.geo.lng}</td><td>${data[i].phone}</td><td>${data[i].website}</td></tr>`

                tbody.innerHTML = tbody.innerHTML + row;
            }
        })
}


getUsers()


