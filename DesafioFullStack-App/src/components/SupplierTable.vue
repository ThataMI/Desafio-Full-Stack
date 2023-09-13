<template>
    <div>
      <Message :msg="msg" v-show="msg" />
      <input v-model="SearchName" @change="getSuppliersName" placeholder="Pesquisar nome"> 
      <input v-model="SearchCnpjCpf" @change="getSuppliersCnpjCpf" placeholder="Pesquisar cnpj ou cpf">
      <table class="table">
  <thead>
    <tr>
      <th scope="col">Nome</th>
      <th scope="col">Cnpj/Cpf</th>
      <th scope="col">Cep</th>
      <th scope="col">E-mail</th>
      <th scope="col">Rg</th>
      <th scope="col">Data de Nascimento</th>
      <th scope="col">Ação</th>
    </tr>
  </thead>
  <tbody>
    <tr  v-for="supplier in supplierFilter"
          v-bind:key="supplier.suppliersId">
      <td> {{ supplier.name }}</td>
      <td> {{ supplier.cnpjCpf }}</td>
      <td> {{supplier.cep}}</td>
      <td> {{supplier.email}}</td>
      <td> {{supplier.rg}}</td>
      <td> {{supplier.birthday}}</td>
      <td>  <button
              class="delete-btn"
              @click="deleteCompany(supplier.suppliersId)"
            >
              Deletar
            </button></td>
    </tr>
    
  </tbody>
</table>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  import Message from "./Message";
  
  export default {
    name: "SupplierTable",
  
    data() {
      return {
        suppliers: [],
        supplierFilter: [],
        msg: "",
      };
    },
    methods: {
      getSuppliers() {
        axios
          .get("https://localhost:7237/api/suppliers/GetAll")
          .then((res) => {
            this.suppliers = res.data;
            this.supplierFilter = res.data;
          })
          .catch(function (error) {
            console.error(error);
          });
      },
      getSuppliersName () {
        if(this.SearchName.length > 0){
          this.supplierFilter = this.suppliers.filter(supplier => supplier.name.toLowerCase().includes(this.SearchName.toLowerCase()));
        }else{
          this.supplierFilter = this.suppliers;
        }
      },
      getSuppliersCnpjCpf () {
        if(this.SearchCnpjCpf.length > 0){
          this.supplierFilter = this.suppliers.filter(supplier => supplier.cnpjCpf.toLowerCase().includes(this.SearchCnpjCpf.toLowerCase()));
        }else{
          this.supplierFilter = this.suppliers;
        }
      },
      deleteCompany(id) {
        if (confirm("Desaja deletar essa empresa?")) {
          axios
            .delete(`https://localhost:7237/api/suppliers/Delete/${id}`)
            .then((res) => {
              this.suppliers = res.data;
              this.supplierFilter = res.data;
              this.getSuppliers();
              this.msg = "Empresa Deletada";
              setTimeout(() => (this.msg = ""), 2000);
            })
            .catch((error) => {
              console.log(error);
            });
        }
      },
    },
    created() {
      this.getSuppliers();
    },
    components: {
      Message,
    },
  };
  </script>
  
  <style scoped>
  input {
  padding: 5px 10px;
  width: 300px;
  border-radius: 10px;
  font-size: 16px;
  margin-top: 10px;
  margin-bottom: 10px;
  margin-left: 10px;
  border-color: #987bad;
}
  .delete-btn {
  background-color: #222;
  color           : #987bad;
  font-weight     : bold;
  border          : 2px solid #222;
  padding         : 10px;
  font-size       : 16px;
  margin          : 0 auto;
  cursor          : pointer;
  transition      : 0.5s;
  }
  
  .delete-btn:hover {
    background-color: transparent;
    color: #222;
  }
  </style>
  