const professionData = document.getElementsByName('ProfessionName');
const countData = document.getElementsByName('ProfessionCount');

var data = [];


//.attributes.getNamedItem("value").nodeValue


var xScale = d3.scaleBand().range([0, width]).padding(0.4),
    yScale = d3.scaleLinear().range([height, 0]);



var g = svg.append("g")
    .attr("transform", "translate(" + 100 + "," + 100 + ")");



// set "dict" data
for (var i = 0; i < professionData.length; i++)
{
    data.push({
        "profession": professionData.item(i).attributes.getNamedItem("value").nodeValue,
       "count": countData.item(i).attributes.getNamedItem("value").nodeValue,
    })
}

//convert the data to csv file
let csvContent = "data:text/csv;charset=utf-8,"
    + data.map(e => e.join(",")).join("\n");


var encodedUri = encodeURI(csvContent);




// set the dimensions and margins of the graph
var margin = { top: 30, right: 30, bottom: 70, left: 60 },
    width = 460 - margin.left - margin.right,
    height = 400 - margin.top - margin.bottom;

// append the svg object to the body of the page
var svg = d3.select("#barChart")
    .append("svg")
    .attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom)
    .append("g")
    .attr("transform",
        "translate(" + margin.left + "," + margin.top + ")");




// Parse the Data
d3.csv(encodedUri, function (data) {



    // sort data
    data.sort(function (b, a) {
        return a.Value - b.Value;
    });

    // X axis
    var x = d3.scaleBand()
        .range([0, width])
        .domain(data.map(function (d) { return d.Country; }))
        .padding(0.2);
    svg.append("g")
        .attr("transform", "translate(0," + height + ")")
        .call(d3.axisBottom(x))
        .selectAll("text")
        .attr("transform", "translate(-10,0)rotate(-45)")
        .style("text-anchor", "end");

    // Add Y axis
    var y = d3.scaleLinear()
        .domain([0, 13000])
        .range([height, 0]);
    svg.append("g")
        .call(d3.axisLeft(y));

    // Bars
    svg.selectAll("mybar")
        .data(data)
        .enter()
        .append("rect")
        .attr("x", function (d) { return x(d.profession); })
        .attr("y", function (d) { return y(d.count); })
        .attr("width", x.bandwidth())
        .attr("height", function (d) { return height - y(d.Value); })
        .attr("fill", "#69b3a2");

})
























 /*   xScale.domain(data.map(function (d) { return d.year; }));
    yScale.domain([0, d3.max(data, function (d) { return d.value; })]);

    g.append("g")
        .attr("transform", "translate(0," + height + ")")
        .call(d3.axisBottom(xScale));

    g.append("g")
        .call(d3.axisLeft(yScale).tickFormat(function (d) {
            return "$" + d;
        }).ticks(10));


    g.selectAll(".bar")
        .data(data)
        .enter().append("rect")
        .attr("class", "bar")
        .attr("x", function (d) { return xScale(d.year); })
        .attr("y", function (d) { return yScale(d.value); })
        .attr("width", xScale.bandwidth())
        .attr("height", function (d) { return height - yScale(d.value); });
        */