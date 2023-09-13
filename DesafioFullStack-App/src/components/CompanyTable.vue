<template>
  <div>
    <Message :msg="msg" v-show="msg" />
    <table class="table">
  <thead>
    <tr>
      <th scope="col">Nome</th>
      <th scope="col">Cep</th>
      <th scope="col">Cnpj</th>
      <th scope="col">Ação</th>
    </tr>
  </thead>
  <tbody>
    <tr  v-for="company in companies"
          v-bind:key="company.companiesId">
      <td> {{ company.name }}</td>
      <td> {{ company.cep }}</td>
      <td> {{company.cnpj}}</td>
      <td>  <button
              class="delete-btn"
              @click="deleteCompany(company.companiesId)"
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
  name: "CompanyTable",

  data() {
    return {
      companies: [],
      company: undefined,
      msg: "",
    };
  },
  methods: {
    getCompanies() {
      axios
        .get("https://localhost:7237/api/companies/Get")
        .then((res) => {
          this.companies = res.data;
        })
        .catch(function (error) {
          console.error(error);
        });
    },
    deleteCompany(id) {
      if (confirm("Desaja deletar essa empresa?")) {
        axios
          .delete(`https://localhost:7237/api/companies/Delete/${id}`)
          .then((res) => {
            this.companies = res.data;
            this.getCompanies();
            this.msg = "Empresa Deletada";
            setTimeout(() => (this.msg = ""), 2000);
          })
          .catch((error) => {
            console.log(error);
          });
      }
    }
  },
  created() {
    this.getCompanies();
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
