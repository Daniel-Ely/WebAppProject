﻿var professionData = { ProList: document.getElementsByName('ProfessionName') }
var countData = { CountList: document.getElementsByName('ProfessionCount') }

let data = [];


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


    xScale.domain(data.map(function (d) { return d.year; }));
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
});