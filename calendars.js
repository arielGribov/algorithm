let data =
    [
        {
            name: "Betty",
            meetings: [
                { startTime: "2021-03-10T09:55:39+00:00", endTime: "2021-03-10T10:15:39+00:00", subject: "Meeting 2" },
                { startTime: "2021-03-10T08:55:39+00:00", endTime: "2021-03-10T09:15:39+00:00", subject: "Meeting 1" },
                { startTime: "2021-03-10T11:55:39+00:00", endTime: "2021-03-10T12:15:39+00:00", subject: "Meeting 3" }
            ]
        },
        {
            name: "John",
            meetings: [
                { startTime: "2021-03-10T08:15:39+00:00", endTime: "2021-03-10T09:55:39+00:00", subject: "Meeting a" },
                { startTime: "2021-03-10T11:15:39+00:00", endTime: "2021-03-10T12:55:39+00:00", subject: "Meeting c" },
                { startTime: "2021-03-10T10:15:39+00:00", endTime: "2021-03-10T10:55:39+00:00", subject: "Meeting b" }
            ]
        }
    ];
const main = (data) => {
    let arr=combine(data);
    for (let date in arr) {
        arr[date].startTime = (new Date(arr[date].startTime)).getTime();
        arr[date].endTime = (new Date(arr[date].endTime)).getTime();
    }
    arr = mergeSort(arr);
    arr = deleteLapMeetings(arr);
    arr = findEmptySlots(arr);
    for (let date in arr) {
        arr[date].startTime = new Date(arr[date].startTime).toISOString();
        arr[date].endTime = new Date(arr[date].endTime).toISOString();
    }
    return arr;
}
const combine = (people) => {
    let combinedArr = [];
    for (let person in people) {
        for (let meeting in people[person].meetings)
            combinedArr.push(people[person].meetings[meeting])
    }
    return combinedArr;
}
const findEmptySlots = (arr) => {
    let eightAm = new Date("2021-03-10T08:00:00+00:00").getTime();
    let eightPm = new Date("2021-03-10T20:00:00+00:00").getTime();

    let result = [{ startTime: eightAm, endTime: arr[0].startTime }];
    for (let i = 1; i < arr.length - 1; i++) {
        if (arr[i].endTime < arr[i + 1].startTime & i !== arr.length - 1)
            result.push({ startTime: arr[i].endTime, endTime: arr[i + 1].startTime });
    }
    result.push({ startTime: arr[arr.length - 1].endTime, endTime: eightPm });
    return result;
}
const mergeSort = (arr) => {
    if (arr.length <= 1) return arr;

    const halfArrLen = Math.floor(arr.length / 2);
    const sortedHalfFirst = mergeSort(arr.slice(0, halfArrLen));
    const sortedHalfsecond = mergeSort(arr.slice(halfArrLen));

    return mergeTwoSortedArrays(sortedHalfFirst, sortedHalfsecond);
}
const mergeTwoSortedArrays = (arr1, arr2) => {
    let i = 0, j = 0;
    const sortedarr = [];
    while (i !== arr1.length || j !== arr2.length) {
        if (arr1[i] != null) {
            if ((j === arr2.length || arr1[i].startTime <= arr2[j].startTime) && i < arr1.length) {
                sortedarr.push(arr1[i]);
                i++;
                continue;
            }
        }
        if (arr2[j] != null) {
            if ((i === arr1.length || arr2[j].startTime < arr1[i].startTime) && j < arr2.length) {
                sortedarr.push(arr2[j]);
                j++;
            }
        }
    }
    return sortedarr;
}
const deleteLapMeetings = (meetings) => {
    for (let i in meetings) {
        for (let j in meetings) {
            if (i !== j && meetings[i].startTime <= meetings[j].startTime && meetings[i].endTime >= meetings[j].endTime)
                meetings.splice(j, 1);
        }
    }
    return meetings
}
console.log(main(data));
