let rest = {};

// تابع کمکی برای دریافت توکن
rest.getAntiForgeryToken = () => {
    let token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
    if (!token) {
        token = document.querySelector('meta[name="__RequestVerificationToken"]')?.content;
    }
    if (!token) {
        const match = document.cookie.match(/__RequestVerificationToken=([^;]+)/);
        token = match ? match[1] : null;
    }
    return token;
};

// تابع کمکی برای ایجاد هدرها
rest.getHeaders = (contentType = 'application/json') => {
    const headers = new Headers();
    headers.append("Accept", "application/json");
    headers.append("X-Requested-With", "XMLHttpRequest");

    if (contentType) {
        headers.append("Content-Type", contentType);
    }

    const token = rest.getAntiForgeryToken();

    if (token) {
        headers.append("RequestVerificationToken", token);
    }

    return headers;
};

rest.get = (url, params, callback = null) => {
    try {
        // Append params to url
        if (params) {
            url = url + "?" + new URLSearchParams(params);
        }

        // Send GET request
        fetch(url, {
            method: 'GET',
            redirect: 'follow',
            headers: rest.getHeaders(null) // No Content-Type for GET
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            })
            .then(result => {
                if (callback) callback(true, result);
            })
            .catch(error => {
                console.error('GET Error:', error);
                if (callback) callback(false, {
                    message: error.message,
                    status: error.status
                });
            });
    } catch (e) {
        console.error('GET Exception:', e);
        if (callback) {
            callback(false, {
                message: e.message,
                stack: e.stack
            });
        }
    }
};

rest.getAsync = async (url, params, callback = null) => {
    try {
        if (params) {
            url = url + "?" + new URLSearchParams(params);
        }

        const requestOptions = {
            method: 'GET',
            redirect: 'follow',
            headers: rest.getHeaders(null)
        };

        const response = await fetch(url, requestOptions);

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();

        if (callback) {
            return callback(true, result);
        }

        return result;

    } catch (error) {
        console.error('GET Async Error:', error);

        if (callback) {
            return callback(false, {
                message: error.message,
                status: error.status || 500
            });
        }

        throw error;
    }
};

rest.post = (url, body, callback = null) => {
    try {
        const requestOptions = {
            method: 'POST',
            headers: rest.getHeaders(),
            body: JSON.stringify(body),
            redirect: 'follow'
        };

        fetch(url, requestOptions)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            })
            .then(result => {
                if (callback) callback(true, result);
            })
            .catch(error => {
                console.error('POST Error:', error);
                if (callback) callback(false, {
                    message: error.message,
                    status: error.status
                });
            });
    } catch (e) {
        console.error('POST Exception:', e);
        if (callback) {
            callback(false, {
                message: e.message,
                stack: e.stack
            });
        }
    }
};

rest.postAsync = async (url, params, body, callback = null) => {

    try {
        if (params) {
            url = url + "?" + new URLSearchParams(params);
        }

        const requestOptions = {
            method: 'POST',
            headers: rest.getHeaders(),
            redirect: 'follow'
        };

        if (body) {
            requestOptions.body = JSON.stringify(body);
        }

        const response = await fetch(url, requestOptions);
      
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();

        if (callback) {
            return callback(true, result);
        }

        return result;

    } catch (error) {
        console.error('POST Async Error:', error);

        if (callback) {
            return callback(false, {
                message: error.message,
                status: error.status || 500
            });
        }

        throw error;
    }
};

// متدهای اضافی برای فرم داده
rest.postForm = (url, formData, callback = null) => {
    try {
        const headers = rest.getHeaders(null); // No Content-Type for FormData
        headers.delete('Content-Type'); // Let browser set Content-Type with boundary

        const requestOptions = {
            method: 'POST',
            headers: headers,
            body: formData,
            redirect: 'follow'
        };

        fetch(url, requestOptions)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            })
            .then(result => {
                if (callback) callback(true, result);
            })
            .catch(error => {
                console.error('POST Form Error:', error);
                if (callback) callback(false, {
                    message: error.message,
                    status: error.status
                });
            });
    } catch (e) {
        console.error('POST Form Exception:', e);
        if (callback) {
            callback(false, {
                message: e.message,
                stack: e.stack
            });
        }
    }
};

// متد PUT
rest.put = async (url, body, callback = null) => {
    try {
        const requestOptions = {
            method: 'PUT',
            headers: rest.getHeaders(),
            body: JSON.stringify(body),
            redirect: 'follow'
        };

        const response = await fetch(url, requestOptions);

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();

        if (callback) {
            return callback(true, result);
        }

        return result;

    } catch (error) {
        console.error('PUT Error:', error);

        if (callback) {
            return callback(false, {
                message: error.message,
                status: error.status || 500
            });
        }

        throw error;
    }
};

// متد DELETE
rest.delete = async (url, params = null, callback = null) => {
    try {
        if (params) {
            url = url + "?" + new URLSearchParams(params);
        }

        const requestOptions = {
            method: 'DELETE',
            headers: rest.getHeaders(),
            redirect: 'follow'
        };

        const response = await fetch(url, requestOptions);

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();

        if (callback) {
            return callback(true, result);
        }

        return result;

    } catch (error) {
        console.error('DELETE Error:', error);

        if (callback) {
            return callback(false, {
                message: error.message,
                status: error.status || 500
            });
        }

        throw error;
    }
};

// نمونه استفاده:
/*
// GET
rest.get('/api/data', { id: 1 }, (success, data) => {
    if (success) {
        console.log('Data:', data);
    } else {
        console.error('Error:', data);
    }
});

// POST
rest.post('/api/data', { name: 'John', age: 30 }, (success, result) => {
    if (success) {
        console.log('Success:', result);
    } else {
        console.error('Error:', result);
    }
});

// POST with FormData
const formData = new FormData();
formData.append('file', fileInput.files[0]);
formData.append('name', 'John');

rest.postForm('/api/upload', formData, (success, result) => {
    if (success) {
        console.log('Upload success:', result);
    } else {
        console.error('Upload error:', result);
    }
});
*/

//// حذف با پارامتر در URL
//rest.delete('/api/users/delete', { id: 123 }, (success, result) => {
//    if (success) {
//        console.log('User deleted successfully:', result);
//        alert('کاربر با موفقیت حذف شد');
//    } else {
//        console.error('Delete error:', result);
//        alert('خطا در حذف کاربر: ' + result.message);
//    }
//});

//// حذف بدون پارامتر
//rest.delete('/api/products/5', null, (success, result) => {
//    if (success) {
//        console.log('Product deleted:', result);
//    } else {
//        console.error('Delete failed:', result);
//    }
//});

//// استفاده با async/await
//async function deleteItem(itemId) {
//    try {
//        const result = await rest.delete('/api/items/delete', { id: itemId });
//        console.log('Item deleted:', result);
//        return result;
//    } catch (error) {
//        console.error('Delete error:', error);
//        throw error;
//    }
//}

//// فراخوانی تابع async
//deleteItem(456).then(result => {
//    console.log('Delete completed:', result);
//});



//// آپلود فایل
//document.getElementById('uploadForm').addEventListener('submit', function (e) {
//    e.preventDefault();

//    const formData = new FormData(this);

//    rest.postForm('/api/upload', formData, (success, result) => {
//        if (success) {
//            console.log('Upload successful:', result);
//            alert('فایل با موفقیت آپلود شد');
//        } else {
//            console.error('Upload error:', result);
//            alert('خطا در آپلود فایل: ' + result.message);
//        }
//    });
//});

//// آپلود چندین فایل
//function uploadFiles(files) {
//    const formData = new FormData();

//    files.forEach((file, index) => {
//        formData.append(`files[${index}]`, file);
//    });

//    formData.append('description', 'Multiple files upload');

//    rest.postForm('/api/upload/multiple', formData, (success, result) => {
//        if (success) {
//            console.log('Files uploaded:', result);
//        } else {
//            console.error('Upload failed:', result);
//        }
//    });
//}