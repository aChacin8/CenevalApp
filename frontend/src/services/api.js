const API_BASE = 'http://localhost:5282/api';

export const api = {
  // === USUARIOS ===
  async register(username, password, fullName) {
    const res = await fetch(`${API_BASE}/users/register`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ username, password, fullName }),
    });
    const data = await res.json();
    if (!res.ok) throw new Error(data.message || 'Error al registrar');
    return data;
  },

  async login(username, password) {
    const res = await fetch(`${API_BASE}/users/login`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ username, password }),
    });
    const data = await res.json();
    if (!res.ok) throw new Error(data.message || 'Credenciales inválidas');
    return data;
  },

  // === EVALUACIÓN ===
  async getStatus(userId) {
    const res = await fetch(`${API_BASE}/ceneval/status/${userId}`);
    if (!res.ok) throw new Error('Error al obtener estado');
    return res.json();
  },

  async getNextQuestion(userId) {
    const res = await fetch(`${API_BASE}/ceneval/next-question/${userId}`);
    if (!res.ok) {
      const data = await res.json().catch(() => ({}));
      throw new Error(data || 'No hay más preguntas');
    }
    return res.json();
  },

  async submitAnswer(userId, optionId) {
    const res = await fetch(`${API_BASE}/ceneval/submit-answer`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ userId, optionId }),
    });
    if (!res.ok) throw new Error('Error al enviar respuesta');
    return res.json();
  },

  async restartExam(userId) {
    const res = await fetch(`${API_BASE}/ceneval/restart/${userId}`, {
      method: 'POST',
    });
    if (!res.ok) throw new Error('Error al reiniciar evaluación');
    return res.json();
  },

  async confirmLevelUp(userId, accept) {
    const res = await fetch(`${API_BASE}/ceneval/confirm-levelup/${userId}`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ accept }),
    });
    if (!res.ok) throw new Error('Error al confirmar subida de nivel');
    return res.json();
  },

  // === HISTORIAL DE EVALUACIONES ===
  async getEvaluations(userId) {
    const res = await fetch(`${API_BASE}/evaluations/${userId}`);
    if (!res.ok) throw new Error('Error al obtener historial de evaluaciones');
    return res.json();
  },

  async getEvaluationDetails(userId, evaluationId) {
    const res = await fetch(`${API_BASE}/evaluations/${userId}/details/${evaluationId}`);
    if (!res.ok) throw new Error('Error al obtener detalles de la evaluación');
    return res.json();
  },
};
