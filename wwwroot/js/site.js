// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let modal = document.querySelector('#modal');

if (modal) {
    let myLinks = document.querySelectorAll('.my-link');
    let closeModal = document.querySelector(".my-modal-close");
    let modalDiv = document.querySelector("#modal_div_content"); 

    closeModal.addEventListener("click", () => {
        modal.style.display = "none";
    });

    window.addEventListener("click", (e) => {
        if (e.target == modal) {
            modal.style.display = "none";
        }
    });
    
    myLinks.forEach(element => {
        element.addEventListener("click", () => {
            if (modal.style.display == "none") {
                modal.style.display = "block";
            }
            else {
                modal.style.display = "none";
            }
            sendRequestWithJSONResponse(modalDiv, element.id);
        });
    });
}

let my_teams_list = document.querySelector("#my_teams_list");
if (my_teams_list) {
    let list_my_teams_favorite = document.querySelectorAll(".list-my-teams-favorite");
    let hiddenCurrentUserId = document.querySelector("#currentUserId");

    list_my_teams_favorite.forEach(element => {
        element.addEventListener("click", () => {
            sendRequest(hiddenCurrentUserId.value, element.id, 2);
        });
    });

    let list_my_teams = document.querySelectorAll(".list-my-teams");
    list_my_teams.forEach(element => {
        element.addEventListener("click", () => {
            sendRequest(hiddenCurrentUserId.value, element.id, 1);
        });
    });
}

function sendRequestWithJSONResponse(modalDivData, teamId) {
    const xmlhttp = new XMLHttpRequest();
    modalDivData.innerHTML = null;

    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let myObj = JSON.parse(this.responseText);
            modalDivData.appendChild(createHTMLResponse(myObj));
        }
    }
    xmlhttp.open("GET", "/Details?id=" + teamId, true);
    xmlhttp.send();
}


function sendRequest(userId, teamId, action) {
    const xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            location.reload();
        }
    }
    xmlhttp.open("GET", "/MyTeams/TeamList?UserId=" + userId + "&TeamId=" + teamId + "&Action=" + action, true);
    // xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xmlhttp.send();
}

function createHTMLResponse(data) {
    if (data instanceof Object) {
        let mainDiv = document.createElement("div");

        let h3 = document.createElement("h3");
        h3.classList.add("text-center");
        h3.classList.add("mb-3");
        h3.classList.add("mt-2");
        h3.innerText = data.Name;

        let table1div = document.createElement("div");
        table1div.classList.add("table-responsive");
        table1div.classList.add("mb-3");

        let table1 = document.createElement("table");
        table1.classList.add("table");

        let table1head = document.createElement("thead");
        table1head.classList.add("text-center");

        let table1headRow = document.createElement("tr");
        table1headRow.classList.add("table-primary");

        let table1headRowElement1 = document.createElement("th");
        table1headRowElement1.setAttribute("scope", "col");
        table1headRowElement1.innerText = "Total Points";

        let table1headRowElement2 = document.createElement("th");
        table1headRowElement2.setAttribute("scope", "col");
        table1headRowElement2.innerText = "Number of Matches Played";

        let table1headRowElement3 = document.createElement("th");
        table1headRowElement3.setAttribute("scope", "col");
        table1headRowElement3.innerText = "Total Goals Scored";

        let table1headRowElement4 = document.createElement("th");
        table1headRowElement4.setAttribute("scope", "col");
        table1headRowElement4.innerText = "Total Goals Conceded";

        table1headRow.appendChild(table1headRowElement1);
        table1headRow.appendChild(table1headRowElement2);
        table1headRow.appendChild(table1headRowElement3);
        table1headRow.appendChild(table1headRowElement4);

        table1head.appendChild(table1headRow);
        table1.appendChild(table1head);

        let table1body = document.createElement("tbody");
        table1body.classList.add("text-center");

        let table1bodyRow = document.createElement("tr");
        table1bodyRow.classList.add("table-info");

        let table1bodyRowElement1 = document.createElement("td");
        table1bodyRowElement1.innerText = data.Points;

        let table1bodyRowElement2 = document.createElement("td");
        table1bodyRowElement2.innerText = data.NumberOfMatches;

        let table1bodyRowElement3 = document.createElement("td");
        table1bodyRowElement3.innerText = data.GoalsScored;

        let table1bodyRowElement4 = document.createElement("td");
        table1bodyRowElement4.innerText = data.GoalsConceded;

        table1bodyRow.appendChild(table1bodyRowElement1);
        table1bodyRow.appendChild(table1bodyRowElement2);
        table1bodyRow.appendChild(table1bodyRowElement3);
        table1bodyRow.appendChild(table1bodyRowElement4);

        table1body.appendChild(table1bodyRow);
        table1.appendChild(table1body);

        table1div.appendChild(table1);


        let table2div = document.createElement("div");
        table2div.classList.add("table-responsive");
        table2div.classList.add("mb-3");

        let table2 = document.createElement("table");
        table2.classList.add("table");

        let table2head = document.createElement("thead");
        table2head.classList.add("text-center");

        let table2headRow = document.createElement("tr");
        table2headRow.classList.add("table-active");

        let table2headRowElement1 = document.createElement("th");
        table2headRowElement1.setAttribute("scope", "col");
        table2headRowElement1.innerText = "Round Number";

        let table2headRowElement2 = document.createElement("th");
        table2headRowElement2.setAttribute("scope", "col");
        table2headRowElement2.innerText = "Result";

        let table2headRowElement3 = document.createElement("th");
        table2headRowElement3.setAttribute("scope", "col");
        table2headRowElement3.innerText = "Points";

        let table2headRowElement4 = document.createElement("th");
        table2headRowElement4.setAttribute("scope", "col");
        table2headRowElement4.innerText = "Opponent";

        let table2headRowElement5 = document.createElement("th");
        table2headRowElement5.setAttribute("scope", "col");
        table2headRowElement5.innerText = "Match Place";

        let table2headRowElement6 = document.createElement("th");
        table2headRowElement6.setAttribute("scope", "col");
        table2headRowElement6.innerText = "Match Date";

        table2headRow.appendChild(table2headRowElement1);
        table2headRow.appendChild(table2headRowElement2);
        table2headRow.appendChild(table2headRowElement3);
        table2headRow.appendChild(table2headRowElement4);
        table2headRow.appendChild(table2headRowElement5);
        table2headRow.appendChild(table2headRowElement6);

        table2head.appendChild(table2headRow);
        table2.appendChild(table2head);

        let table2body = document.createElement("tbody");
        table2body.classList.add("text-center");

        for (let i = 0; i < data.Rounds.length; i++) {
            let table2bodyRow = document.createElement("tr");

            let table2bodyRowElement1 = document.createElement("td");
            table2bodyRowElement1.innerText = data.Rounds[i].RoundNumber;

            let table2bodyRowElement2 = document.createElement("td");
            let result = "0:0";
            let matchPlace = "Home";
            let points = 0;
            if (data.Rounds[i].FirstTeam.Statistics == null) {
                let stats = data.Rounds[i].SecondTeam.Statistics[i];
                result = stats.GoalsScored + " : " + stats.GoalsConceded;
                matchPlace = "Away";
                points = stats.PointsPerMatch;
            }
            else {
                let stats = data.Rounds[i].FirstTeam.Statistics[i];
                result = stats.GoalsScored + " : " + stats.GoalsConceded;
                points = stats.PointsPerMatch;
            }
            table2bodyRowElement2.innerText = result;

            let table2bodyRowElement3 = document.createElement("td");
            table2bodyRowElement3.innerText = points;

            let table2bodyRowElement4 = document.createElement("td");
            if (data.Rounds[i].FirstTeam.Name == data.Name) {
                table2bodyRowElement4.innerText = data.Rounds[i].SecondTeam.Name;
            }
            else {
                table2bodyRowElement4.innerText = data.Rounds[i].FirstTeam.Name;
            }

            let table2bodyRowElement5 = document.createElement("td");
            table2bodyRowElement5.innerText = matchPlace;
           

            let table2bodyRowElement6 = document.createElement("td");
            table2bodyRowElement6.innerText = data.Rounds[i].Date;

            table2bodyRow.appendChild(table2bodyRowElement1);
            table2bodyRow.appendChild(table2bodyRowElement2);
            table2bodyRow.appendChild(table2bodyRowElement3);
            table2bodyRow.appendChild(table2bodyRowElement4);
            table2bodyRow.appendChild(table2bodyRowElement5);
            table2bodyRow.appendChild(table2bodyRowElement6);

            table2body.appendChild(table2bodyRow);
        }        
        table2.appendChild(table2body);
        table2div.appendChild(table2);

        mainDiv.appendChild(h3);
        mainDiv.appendChild(table1div);
        mainDiv.appendChild(table2div);
        return mainDiv;
    }

    let h1 = document.createElement("h1");
    h1.classList.add("text-center");
    h1.innerText = "No Content";
    return h1;
}
