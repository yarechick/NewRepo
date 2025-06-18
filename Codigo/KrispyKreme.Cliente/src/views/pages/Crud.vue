<script setup>
//import { VentasService } from '@/service/VentasService';
import { FilterMatchMode } from '@primevue/core/api';
import { useToast } from 'primevue/usetoast';
import { useRouter } from 'vue-router';
import { useAuthStore } from '@/stores/auth';
import { onMounted, ref, inject } from 'vue';

const config = inject('config');

const authStore = useAuthStore();
const router = useRouter();
const ventas = ref([]);
const productos = ref([]);
const sucursales = ref([]);
const productosParciales = ref([]);
const productosNew = ref([]);
const clientes = ref([{ label: 'Genérico', value: '1' }]);
const metodosPago = ref([
    { label: 'Efectivo', value: '1' },
    { label: 'Tarjeta debito', value: '2' },
    { label: 'Tarjeta crédito ', value: '3' }
]);
const loading = ref(false);
const error = ref(null);

const API_URL = config.API_URL;

const fetchVentas = () => {
    loading.value = true;
    error.value = null;

    fetch(API_URL + 'Venta')
        .then((response) => {
            if (!response.ok) throw new Error('Error en la petición HTTP: ' + response.status);
            return response.json(); // Convertir a JSON
        })
        .then((data) => {
            ventas.value = data.map((item) => ({
                id: item.ordenId,
                fecha: item.fechaOrden,
                vendedor: item.vendedor,
                sucursal: item.sucursal,
                total: item.total,
                estatus: item.estatusOrden
            }));
        })
        .catch((err) => {
            console.error('Error en fetchVentas:', err);
            error.value = err.message || 'Error desconocido';
        })
        .finally(() => {
            loading.value = false;
        });
};

const postVenta = () => {
    loading.value = true;
    error.value = null;

    const token = localStorage.getItem('jwt');

    if (!token) {
        error.value = 'No autenticado. Por favor inicie sesión.';
        loading.value = false;
        toast.add({ severity: 'error', summary: 'No autenticado', detail: 'Por favor inicie sesión', life: 3000 });
        router.push('/auth/login');
        return;
    }

    fetch(API_URL + 'PostVenta', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },

        body: JSON.stringify({
            ClienteId: ventaAdd.value.clienteId,
            SucursalId: ventaAdd.value.sucursalId,
            MetodoPagoId: ventaAdd.value.metodoPagoId,
            DetalleOrden: !productosNew.value.length === 0 ? [] : productosNew.value
        })
    })
        .then((response) => {
            if (!response.ok) throw new Error('Error en la petición HTTP: ' + response.status);
            if (response.ok) fetchVentas();
            return response.json();
        })
        .then((data) => {})
        .catch((err) => {
            console.error('Error en postVenta:', err);
            error.value = err.message || 'Error al crear la venta';
        })
        .finally(() => {
            loading.value = false;
        });
};

const fetchProductos = () => {
    loading.value = true;
    error.value = null;
    const token = localStorage.getItem('jwt');

    if (!token) {
        error.value = 'No autenticado. Por favor inicie sesión.';
        loading.value = false;
        //toast.add({ severity: 'error', summary: 'No autenticado', detail: 'Por favor inicie sesión', life: 3000 });
        //router.push('/auth/login');
        return;
    }

    fetch(API_URL + 'GetProducto', {
        headers: {
            Authorization: `Bearer ${token}`
        }
    })
        .then((response) => {
            if (response.status === 401) {
                throw new Error('No autorizado. Token inválido o expirado');
            }
            if (!response.ok) throw new Error('Error en la petición HTTP: ' + response.status);
            return response.json();
        })
        .then((data) => {
            productos.value = data.map((item) => ({
                value: item.productoId,
                label: item.nombre + '    ----------->      $' + item.precio,
                precio: item.precio,
                nombre: item.nombre
            }));
        })
        .catch((err) => {
            console.error('Error en fetchProductos:', err);
            error.value = err.message || 'Error desconocido';
        })
        .finally(() => {
            loading.value = false;
        });
};

const fetchSucursales = () => {
    loading.value = true;
    error.value = null;

    const token = localStorage.getItem('jwt');

    if (!token) {
        error.value = 'No autenticado. Por favor inicie sesión.';
        loading.value = false;
        //toast.add({ severity: 'error', summary: 'No autenticado', detail: 'Por favor inicie sesión', life: 3000 });
        //router.push('/auth/login');
        return;
    }

    fetch(API_URL + 'GetSucursal', {
        headers: {
            Authorization: `Bearer ${token}`
        }
    })
        .then((response) => {
            if (response.status === 401) {
                throw new Error('No autorizado. Token inválido o expirado');
            }
            if (!response.ok) throw new Error('Error en la petición HTTP: ' + response.status);
            return response.json();
        })
        .then((data) => {
            sucursales.value = data.map((item) => ({
                value: item.sucursalId,
                label: item.nombre
            }));
        })
        .catch((err) => {
            console.error('Error en fetchSucursales:', err);
            error.value = err.message || 'Error desconocido';
        })
        .finally(() => {
            loading.value = false;
        });
};

onMounted(() => {
    fetchProductos();
    fetchVentas();
    fetchSucursales();
});

const toast = useToast();
const dt = ref();
const products = ref();
const productDialog = ref(false);
const deleteProductDialog = ref(false);
const deleteProductsDialog = ref(false);
const product = ref({});
const productAdd = ref({});
const productNew = ref({});
const venta = ref({});
const ventaAdd = ref({});
const selectedProducts = ref();
const filters = ref({
    global: { value: null, matchMode: FilterMatchMode.CONTAINS }
});
const submitted = ref(false);

function formatCurrency(value) {
    if (value) return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    return;
}

function openNew() {
    product.value = {};
    productAdd.value = {};
    submitted.value = false;
    productDialog.value = true;
}

function hideDialog() {
    productDialog.value = false;
    submitted.value = false;
}

function saveProduct() {
    submitted.value = true;
    if (product?.value.nombre?.label.trim()) {
        if (product.value.cantidad <= 0) {
            toast.add({ severity: 'error', summary: 'Validación de datos', detail: 'Cantidad debe mayor a 0', life: 3000 });
        } else {
            productAdd.value.id = product.value.nombre.value;
            productAdd.value.code = createId();
            productAdd.value.nombre = product.value.nombre.nombre;
            productAdd.value.cantidad = product.value.cantidad;
            productAdd.value.precio = product.value.nombre.precio;
            productAdd.value.subTotal = product.value.cantidad * product.value.nombre.precio;

            productNew.value.OrdenId = 0;
            productNew.value.ProductoId = product.value.nombre.value;
            productNew.value.Cantidad = product.value.cantidad;
            productNew.value.Precio = product.value.nombre.precio;
            productosNew.value.push(productNew.value);

            productosParciales.value.push(productAdd.value);
            toast.add({ severity: 'success', summary: 'Se agregó correctamente', detail: 'Producto agregado', life: 3000 });

            //productDialog.value = false;
            product.value.nombre = '';
            product.value.cantidad = '';
            productAdd.value = {};
        }
    }
}

function saveVenta() {
    submitted.value = true;

    if (!productosParciales.value.length) {
        toast.add({ severity: 'error', summary: 'Validación de datos', detail: 'No existen productos', life: 3000 });
    } else {
        ventaAdd.value.sucursalId = venta.value.sucursal.value;
        ventaAdd.value.clienteId = venta.value.cliente.value;
        ventaAdd.value.metodoPagoId = venta.value.metodoPago.value;
        ventaAdd.value.detalleOrden = productosParciales.value;
        //productosParciales.value.push(productAdd.value);

        postVenta();
        toast.add({ severity: 'success', summary: 'Se agregó correctamente', detail: 'Venta agregada', life: 3000 });

        productDialog.value = false;
        product.value.nombre = '';
        product.value.cantidad = '';
        productosParciales.value = [];
        venta.value = {};
        ventaAdd.value = {};

        productDialog.value = false;
    }
}

function editProduct(prod) {
    product.value = { ...prod };
    productDialog.value = true;
}

function confirmDeleteProduct(prod) {
    productAdd.value = prod;
    deleteProductDialog.value = true;
}

function deleteProduct() {
    console.log(productAdd.value.id);
    productosParciales.value = productosParciales.value.filter((val) => val.id !== productAdd.value.id);
    deleteProductDialog.value = false;
    product.value = {};
    toast.add({ severity: 'success', summary: 'Se eliminó correctamente', detail: 'Producto eliminado', life: 3000 });
}

function findIndexById(id) {
    let index = -1;
    for (let i = 0; i < ventas.value.length; i++) {
        if (ventas.value[i].id === id) {
            index = i;
            break;
        }
    }

    return index;
}

function createId() {
    let id = '';
    var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
        id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
}

function exportCSV() {
    dt.value.exportCSV();
}

function confirmDeleteSelected() {
    deleteProductsDialog.value = true;
}
</script>

<template>
    <div>
        <div class="card">
            <Toolbar class="mb-6">
                <template #start>
                    <Button v-if="authStore.isAuthenticated" label="Nueva venta" icon="pi pi-plus" severity="secondary" class="mr-2" @click="openNew" />
                    <!--<Button label="Delete" icon="pi pi-trash" severity="secondary" @click="confirmDeleteSelected" :disabled="!selectedProducts || !selectedProducts.length" /> -->
                </template>

                <template #end>
                    <!-- <Button label="Export" icon="pi pi-upload" severity="secondary" @click="exportCSV($event)" /> -->
                </template>
            </Toolbar>

            <DataTable
                ref="dt"
                v-model:selection="selectedProducts"
                :value="ventas"
                dataKey="id"
                :paginator="true"
                :rows="5"
                :filters="filters"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5, 10, 25]"
                currentPageReportTemplate=" Del {first} al {last} de un total de {totalRecords} registros"
            >
                <template #header>
                    <div class="flex flex-wrap gap-2 items-center justify-between">
                        <h4 class="m-0">Administrar Ventas</h4>
                        <IconField>
                            <InputIcon>
                                <i class="pi pi-search" />
                            </InputIcon>
                            <InputText v-model="filters['global'].value" placeholder="Buscar..." />
                        </IconField>
                    </div>
                </template>

                <Column selectionMode="multiple" style="width: 3rem" :exportable="false"></Column>
                <Column field="id" header="Código" sortable style="min-width: 12rem"></Column>
                <Column field="fecha" header="Fecha" sortable style="min-width: 12rem"></Column>
                <Column field="total" header="Total" sortable style="min-width: 12rem">
                    <template #body="slotProps">
                        {{ formatCurrency(slotProps.data.total) }}
                    </template>
                </Column>
                <Column field="vendedor" header="Vendedor" sortable style="min-width: 12rem"></Column>
                <Column field="sucursal" header="Sucursal" sortable style="min-width: 12rem"></Column>
                <Column field="estatus" header="Estatus" sortable style="min-width: 12rem"></Column>
            </DataTable>
        </div>

        <Dialog v-model:visible="productDialog" :style="{ width: '900px' }" header="Nueva venta" :modal="true">
            <div class="flex flex-col gap-6">
                <div>
                    <label for="sucursal" class="block font-bold mb-3">Sucursal</label>
                    <Select id="sucursal" v-model="venta.sucursal" :options="sucursales" optionLabel="label" placeholder="Selecciona sucursal" fluid></Select>
                    <small v-if="!venta.sucursal" class="text-red-500">Información requerida.</small>
                </div>
                <div>
                    <label for="cliente" class="block font-bold mb-3">Cliente</label>
                    <Select id="cliente" v-model="venta.cliente" :options="clientes" optionLabel="label" placeholder="Selecciona cliente" fluid></Select>
                    <small v-if="!venta.cliente" class="text-red-500">Información requerida.</small>
                </div>
                <div>
                    <label for="MetodoPago" class="block font-bold mb-3">Metodo Pago</label>
                    <Select id="MetodoPago" v-model="venta.metodoPago" :options="metodosPago" optionLabel="label" placeholder="Selecciona metodo de pago" fluid></Select>
                    <small v-if="!venta.metodoPago" class="text-red-500">Información requerida.</small>
                </div>
                <div>
                    <Card>
                        <template v-slot:title>
                            <div class="flex items-center justify-between mb-0">
                                <div class="font-semibold text-xl mb-4">Producto</div>
                                <Button icon="pi pi-plus" @click="saveProduct" />
                            </div>
                        </template>
                        <template v-slot:content>
                            <div>
                                <label for="nombre" class="block font-bold mb-3">Producto</label>
                                <Listbox v-model="product.nombre" :options="productos" optionLabel="label" :filter="true" />
                                <small v-if="!product.nombre" class="text-red-500">Información requerida.</small>
                            </div>
                            <div class="grid grid-cols-12 gap-4">
                                <div class="col-span-6">
                                    <label for="quantity" class="block font-bold mb-3">Cantidad</label>
                                    <InputNumber id="quantity" v-model="product.cantidad" integeronly fluid />
                                    <small v-if="!product.cantidad" class="text-red-500">Información requerida.</small>
                                </div>
                                <div class="col-span-6"></div>
                            </div>
                            <DataTable
                                ref="dt"
                                v-model:selection="selectedProducts"
                                :value="productosParciales"
                                dataKey="id"
                                :paginator="false"
                                :rows="5"
                                :filters="filters"
                                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                                :rowsPerPageOptions="[5, 10, 25]"
                                currentPageReportTemplate=" Del {first} al {last} de un total de {totalRecords} registros"
                            >
                                <template #header>
                                    <div class="flex flex-wrap gap-2 items-center justify-between">
                                        <h4 class="m-0">Productos</h4>
                                    </div>
                                </template>
                                <Column field="id" header="Código" sortable style="min-width: 6rem"></Column>
                                <Column field="nombre" header="Nombre" sortable style="min-width: 6rem"></Column>
                                <Column field="precio" header="Precio" sortable style="min-width: 6rem">
                                    <template #body="slotProps">
                                        {{ formatCurrency(slotProps.data.precio) }}
                                    </template>
                                </Column>
                                <Column field="cantidad" header="Cantidad" sortable style="min-width: 6rem"></Column>
                                <Column field="subTotal" header="Total" sortable style="min-width: 6rem">
                                    <template #body="slotProps">
                                        {{ formatCurrency(slotProps.data.subTotal) }}
                                    </template></Column
                                >
                                <Column :exportable="false" style="min-width: 12rem">
                                    <template #body="slotProps">
                                        <Button icon="pi pi-trash" outlined rounded severity="danger" @click="confirmDeleteProduct(slotProps.data)" />
                                    </template>
                                </Column>
                            </DataTable>
                        </template>
                    </Card>
                </div>
            </div>

            <template #footer>
                <Button label="Cancel" icon="pi pi-times" text @click="hideDialog" />
                <Button label="Save" icon="pi pi-check" @click="saveVenta" />
            </template>
        </Dialog>

        <Dialog v-model:visible="deleteProductDialog" :style="{ width: '450px' }" header="Confirm" :modal="true">
            <div class="flex items-center gap-4">
                <i class="pi pi-exclamation-triangle !text-3xl" />
                <span v-if="product"
                    >Estas segur@ que quieres quitar <b>{{ product.name }}</b
                    >?</span
                >
            </div>
            <template #footer>
                <Button label="No" icon="pi pi-times" text @click="deleteProductDialog = false" />
                <Button label="Si" icon="pi pi-check" @click="deleteProduct" />
            </template>
        </Dialog>

        <Dialog v-model:visible="deleteProductsDialog" :style="{ width: '450px' }" header="Confirm" :modal="true">
            <div class="flex items-center gap-4">
                <i class="pi pi-exclamation-triangle !text-3xl" />
                <span v-if="product">Are you sure you want to delete the selected products?</span>
            </div>
            <template #footer>
                <Button label="No" icon="pi pi-times" text @click="deleteProductsDialog = false" />
                <Button label="Yes" icon="pi pi-check" text @click="deleteSelectedProducts" />
            </template>
        </Dialog>
    </div>
</template>
