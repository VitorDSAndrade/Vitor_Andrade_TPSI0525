# 🧾 Imposter2 — Test Documentation

**Mountebank Port:** `4646`  
**Base URL:** `http://localhost:4646`  
**Descrição:** Este ficheiro documenta todos os testes executados para o `imposter.json` dos Exercícios Imposters 2.  
Cada secção mostra o endpoint testado, os dados de entrada, o resultado esperado e o resultado obtido durante os testes realizados no VS Code REST Client.

---

## ### ===== API 1: STUDENTS =====

### 🧠 Descrição:
Endpoints para listar e criar estudantes.

---

#### ✅ **GET all students (should return list)**
```
GET {{baseUrl}}/api/students
```

**Resultado esperado:**
```json
{
  "status": "success",
  "data": [
    { "id": 1, "name": "Alice", "age": 19, "course": "IT" },
    { "id": 2, "name": "Bob", "age": 21, "course": "Design" }
  ]
}
```

**Resultado obtido:** ✅ Igual ao esperado (200 OK)

---

#### ✅ **Create student (valid)**
```
POST {{baseUrl}}/api/students
Content-Type: application/json
{
  "name": "Charlie",
  "age": 22,
  "course": "Engineering"
}
```

**Resultado esperado:**
```json
{
  "status": "success",
  "data": { "id": 3, "message": "Student created successfully" }
}
```

**Resultado obtido:** ✅ Igual ao esperado (201 Created)

---

#### ❌ **Create student (missing age → 400)**
```
POST {{baseUrl}}/api/students
Content-Type: application/json
{
  "name": "Invalid Student",
  "course": "IT"
}
```

**Resultado esperado:**
```json
{
  "status": "error",
  "error": "missing_field",
  "message": "Field 'age' is required"
}
```

**Resultado obtido:** ✅ Igual ao esperado (400 Bad Request)

---

## ### ===== API 2: PRODUCTS =====

### 🧠 Descrição:
Simula uma loja online, permitindo listar e adicionar produtos.

---

#### ✅ **GET all products**
```
GET {{baseUrl}}/api/products
```

**Resultado esperado:**  
Lista de produtos (status 200 OK)

**Resultado obtido:** ✅ Igual ao esperado

---

#### ✅ **Create product (valid)**
```
POST {{baseUrl}}/api/products
{
  "name": "Monitor",
  "price": 199.99,
  "stock": 25
}
```

**Resultado esperado:**
```json
{
  "status": "success",
  "data": { "id": 3, "message": "Product added successfully" }
}
```

**Resultado obtido:** ✅ Igual (201 Created)

---

#### ❌ **Create product (missing stock → 400)**
```
POST {{baseUrl}}/api/products
{
  "name": "Incomplete Product",
  "price": 45.00
}
```

**Resultado esperado:** erro `missing_stock`

**Resultado obtido:** ✅ Igual (400 Bad Request)

---

## ### ===== API 3: RESERVATIONS =====

### 🧠 Descrição:
Gestão de reservas de hotel.

---

#### ✅ **GET all reservations**
```
GET {{baseUrl}}/api/reservations
```
**Esperado:** Lista de reservas (200 OK)  
**Obtido:** ✅ Igual

---

#### ✅ **Create reservation (valid)**
```
POST {{baseUrl}}/api/reservations
{
  "client": "Maria",
  "room": 305,
  "nights": 4
}
```

**Esperado:** 201 Created + `"Reservation created"`  
**Obtido:** ✅ Igual

---

#### ❌ **Create reservation (missing room → 400)**
```
POST {{baseUrl}}/api/reservations
{
  "client": "Missing Room"
}
```

**Esperado:** erro `"Room field is required"`  
**Obtido:** ✅ Igual

---

## ### ===== API 4: LIBRARY =====

### 🧠 Descrição:
Simula empréstimos de livros e disponibilidade.

---

#### ✅ **GET all books**
```
GET {{baseUrl}}/api/books
```

**Esperado:** 200 + lista de livros  
**Obtido:** ✅ Igual

---

#### ❌ **Create loan (book 2 unavailable)**
```
POST {{baseUrl}}/api/loans
{
  "bookId": 2,
  "user": "Ana"
}
```

**Esperado:** 400 + erro `"book_unavailable"`  
**Obtido:** ✅ Igual

---

#### ✅ **Create loan (valid)**
```
POST {{baseUrl}}/api/loans
{
  "bookId": 1,
  "user": "Ana"
}
```

**Esperado:** 201 Created + `"Loan registered successfully"`  
**Obtido:** ✅ Igual

---

## ### ===== API 5: EMPLOYEES =====

### 🧠 Descrição:
Gestão de funcionários (nome, cargo e salário).

---

#### ✅ **GET all employees**
```
GET {{baseUrl}}/api/employees
```

**Esperado:** 200 OK + lista de funcionários  
**Obtido:** ✅ Igual

---

#### ✅ **Create employee (valid)**
```
POST {{baseUrl}}/api/employees
{
  "name": "Miguel",
  "role": "Support",
  "salary": 1200
}
```

**Esperado:** 201 + `"Employee created"`  
**Obtido:** ✅ Igual

---

#### ❌ **Create employee (salary = 0)**
```
POST {{baseUrl}}/api/employees
{
  "name": "Fake",
  "role": "Intern",
  "salary": 0
}
```

**Esperado:** 400 + `"Salary must be greater than zero"`  
**Obtido:** ✅ Igual

---

## ### ===== API 6: TASKS =====

### 🧠 Descrição:
Gestão de tarefas (criação e verificação de duplicados).

---

#### ✅ **GET all tasks**
```
GET {{baseUrl}}/api/tasks
```

**Esperado:** 200 OK + lista de tarefas  
**Obtido:** ✅ Igual

---

#### ✅ **Create task (valid)**
```
POST {{baseUrl}}/api/tasks
{
  "title": "Finish report"
}
```

**Esperado:** 201 Created  
**Obtido:** ✅ Igual

---

#### ❌ **Create task (duplicate title → 409)**
```
POST {{baseUrl}}/api/tasks
{
  "title": "duplicate"
}
```

**Esperado:** 409 + `"Task already exists"`  
**Obtido:** ✅ Igual

---

## ### ===== API 7: CUSTOMERS & ORDERS =====

### 🧠 Descrição:
Simula clientes e pedidos associados.

---

#### ✅ **GET all customers**
```
GET {{baseUrl}}/api/customers
```

**Esperado:** 200 OK + lista de clientes  
**Obtido:** ✅ Igual

---

#### ✅ **Create order (valid)**
```
POST {{baseUrl}}/api/orders
{
  "customerId": 1,
  "product": "Laptop",
  "quantity": 2
}
```

**Esperado:** 201 Created + `"Order created successfully"`  
**Obtido:** ✅ Igual

---

#### ❌ **Create order (invalid customer → 404)**
```
POST {{baseUrl}}/api/orders
{
  "customerId": 99,
  "product": "Tablet",
  "quantity": 1
}
```

**Esperado:** 404 + `"Customer ID not found"`  
**Obtido:** ✅ Igual

---

## ✅ **Resumo Final**
| API | Total Testes | Sucesso | Erros Esperados | Estado |
|-----|---------------|----------|----------------|---------|
| Students | 3 | 2 | 1 | ✅ |
| Products | 3 | 2 | 1 | ✅ |
| Reservations | 3 | 2 | 1 | ✅ |
| Library | 3 | 2 | 1 | ✅ |
| Employees | 3 | 2 | 1 | ✅ |
| Tasks | 3 | 2 | 1 | ✅ |
| Customers/Orders | 3 | 2 | 1 | ✅ |
| **Total** | **21** | **14 success** | **7 expected errors** | 🟢 Todos OK |
