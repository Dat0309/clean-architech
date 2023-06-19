/**
 * Returns number have '0' before if lower than 10
 * 
 * @param {Number} number The number want to add '0' before
 * @return {Number} The current date have '0' before if lower than 10.
 */
const addZeroBefore = (number) => {
    return (number < 10) ? `0${number}` : number
}

/**
 * Returns current date with format YYYY/MM/DD
 *
 * @return {String} date The current date.
 */
const getCurrentDate = () => {
    const current = new Date();
    const date = `${current.getFullYear()}-${addZeroBefore(current.getMonth() + 1)}-${addZeroBefore(current.getDate())}`;

    return date
}

/**
 * Returns date time string with format DD/MM/YYYY.
 *
 * @param {Date Object} dateTime The dateTime want to convert to string.
 * @return {String} formattedDate The string of dateTime after convert.
 */
const convertDate = (dateTime) => {
    const date = new Date(dateTime);
    const formattedDate = date.toLocaleDateString('en-GB');
    return formattedDate
}

/**
 * Returns key of object from value.
 *
 * @param {Object} obj The object want to get key.
 * @param {String} value The value want to get key from obj.
 * @return {String} The key of object have value.
 */
const getKeyFromValueObj = (obj, value) => {
    return Object.entries(obj).find(x => x[1] === value)[0]
}

/**
 * Returns array string from split string with special character
 *
 * @param {String} str The string want to split to array.
 * @param {String} specialChar The special character want to split from.
 * @return {Array} array string from split string with special character
 */
const convertStringToArray = (str, specialChar) => {
    return str.split(specialChar)
}

/**
 * Returns query string to call API from object with key, value.
 *
 * @param {Object} obj The object want to convert to query.
 * @return {String} query The result from obj with key, value.
 */
const convertObjectToQueryString = (obj) => {
    let query = ''
    if (obj) {
        query =
            '?' +
            Object.keys(obj)
                .map(key => {
                    return `${key}=${encodeURIComponent(obj[key])}`;
                })
                .join('&');
    }
    return query
}

export {
    addZeroBefore,
    getCurrentDate,
    convertDate,
    getKeyFromValueObj,
    convertObjectToQueryString,
    convertStringToArray,
}