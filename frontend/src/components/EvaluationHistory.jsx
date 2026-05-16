import { useState, useEffect, useCallback } from 'react';
import { api } from '../services/api';

// ── Helpers ─────────────────────────────────────────────────────────────────
const DIFF_LABEL = { 3: 'Fácil', 1: 'Normal', 2: 'Difícil' };
const DIFF_COLOR = { 3: '#22c55e', 1: '#f59e0b', 2: '#ef4444' };

function formatDate(iso) {
  if (!iso) return '';
  const d = new Date(iso);
  return d.toLocaleDateString('es-MX', {
    day: '2-digit', month: 'short', year: 'numeric',
    hour: '2-digit', minute: '2-digit',
  });
}

function ScoreBadge({ pct }) {
  const n = Number(pct);
  const color = n >= 70 ? '#22c55e' : n >= 50 ? '#f59e0b' : '#ef4444';
  const bg    = n >= 70 ? '#dcfce7' : n >= 50 ? '#fef9c3' : '#fee2e2';
  return (
    <span style={{
      background: bg, color, border: `1.5px solid ${color}`,
      borderRadius: '999px', padding: '3px 12px',
      fontWeight: 700, fontSize: '0.85rem', whiteSpace: 'nowrap',
    }}>
      {n.toFixed(1)}%
    </span>
  );
}

// ── Fila de pregunta dentro del detalle ─────────────────────────────────────
function DetailRow({ detail, index }) {
  const diff = detail.questionDifficulty;
  const diffColor = DIFF_COLOR[diff] || '#6366f1';
  return (
    <div style={{
      display: 'grid',
      gridTemplateColumns: '28px 1fr 28px',
      gap: '10px',
      alignItems: 'start',
      padding: '10px 12px',
      borderRadius: '10px',
      background: detail.isCorrect ? '#f0fdf4' : '#fff5f5',
      border: `1px solid ${detail.isCorrect ? '#bbf7d0' : '#fecaca'}`,
      marginBottom: '8px',
    }}>
      {/* Número */}
      <div style={{
        width: '28px', height: '28px', borderRadius: '50%',
        background: detail.isCorrect ? '#22c55e' : '#ef4444',
        color: '#fff', display: 'flex', alignItems: 'center', justifyContent: 'center',
        fontWeight: 700, fontSize: '0.75rem', flexShrink: 0,
      }}>
        {index + 1}
      </div>

      {/* Contenido */}
      <div>
        <p style={{ margin: 0, fontWeight: 600, fontSize: '0.88rem', color: '#1e293b', lineHeight: 1.4 }}>
          {detail.questionContent}
        </p>
        <p style={{ margin: '4px 0 0', fontSize: '0.8rem', color: '#64748b' }}>
          <span style={{
            background: diffColor + '22', color: diffColor,
            borderRadius: '4px', padding: '1px 6px', fontWeight: 600, marginRight: '6px',
          }}>
            {DIFF_LABEL[diff] || 'N/A'}
          </span>
          Tu respuesta:{' '}
          <strong style={{ color: detail.isCorrect ? '#16a34a' : '#dc2626' }}>
            {detail.selectedOptionText}
          </strong>
        </p>
        {!detail.isCorrect && detail.questionFeedback && (
          <p style={{ margin: '4px 0 0', fontSize: '0.78rem', color: '#64748b', fontStyle: 'italic' }}>
            💡 {detail.questionFeedback}
          </p>
        )}
      </div>

      {/* Icono */}
      <div style={{ fontSize: '1.1rem', textAlign: 'center', paddingTop: '2px' }}>
        {detail.isCorrect ? '✅' : '❌'}
      </div>
    </div>
  );
}

// ── Tarjeta de evaluación colapsable ─────────────────────────────────────────
function EvaluationCard({ evaluation, userId, index }) {
  const [expanded, setExpanded] = useState(false);
  const [details,  setDetails]  = useState(null);
  const [loading,  setLoading]  = useState(false);
  const [error,    setError]    = useState('');

  const handleToggle = async () => {
    if (!expanded && !details) {
      setLoading(true);
      try {
        const data = await api.getEvaluationDetails(userId, evaluation.evaluationId);
        setDetails(data);
      } catch (e) {
        setError(e.message);
      } finally {
        setLoading(false);
      }
    }
    setExpanded(prev => !prev);
  };

  const pct = Number(evaluation.scorePercentage ?? 0);

  return (
    <div style={{
      border: '1px solid #e2e8f0',
      borderRadius: '14px',
      overflow: 'hidden',
      marginBottom: '12px',
      boxShadow: '0 1px 4px rgba(0,0,0,0.05)',
    }}>
      {/* Cabecera */}
      <button
        id={`eval-card-${evaluation.evaluationId}`}
        onClick={handleToggle}
        style={{
          width: '100%',
          display: 'grid',
          gridTemplateColumns: '1fr auto auto',
          gap: '12px',
          alignItems: 'center',
          background: expanded ? '#f8faff' : '#fff',
          border: 'none',
          padding: '14px 18px',
          cursor: 'pointer',
          textAlign: 'left',
          borderBottom: expanded ? '1px solid #e2e8f0' : 'none',
          transition: 'background 0.2s',
        }}
      >
        <div>
          <p style={{ margin: 0, fontWeight: 700, fontSize: '0.95rem', color: '#1e293b' }}>
            Evaluación #{index + 1}
          </p>
          <p style={{ margin: '2px 0 0', fontSize: '0.8rem', color: '#94a3b8' }}>
            🗓 {formatDate(evaluation.startDateTime)}
          </p>
        </div>

        <span style={{ fontSize: '0.85rem', color: '#64748b', whiteSpace: 'nowrap' }}>
          <strong style={{ color: '#22c55e' }}>{evaluation.correctAnswers}</strong>
          /{evaluation.totalQuestions} correctas
        </span>

        <div style={{ display: 'flex', alignItems: 'center', gap: '10px' }}>
          <ScoreBadge pct={pct} />
          <span style={{
            color: '#94a3b8', fontSize: '0.9rem',
            transform: expanded ? 'rotate(180deg)' : 'rotate(0deg)',
            transition: 'transform 0.25s',
            display: 'inline-block',
          }}>▼</span>
        </div>
      </button>

      {/* Detalle expandido */}
      {expanded && (
        <div style={{ padding: '16px 18px', background: '#fafbff' }}>
          {loading && (
            <div style={{ textAlign: 'center', padding: '20px', color: '#94a3b8' }}>
              <div className="spinner-border spinner-border-sm me-2" role="status"></div>
              Cargando detalle...
            </div>
          )}
          {error && (
            <div style={{ color: '#ef4444', fontSize: '0.85rem' }}>⚠ {error}</div>
          )}
          {details && !loading && (
            <>
              {/* Resumen de métricas */}
              <div style={{ display: 'flex', gap: '12px', marginBottom: '16px', flexWrap: 'wrap' }}>
                {[
                  { label: 'Correctas',   value: details.correctAnswers,                              color: '#22c55e' },
                  { label: 'Incorrectas', value: details.totalQuestions - details.correctAnswers,     color: '#ef4444' },
                  { label: 'Total',       value: details.totalQuestions,                              color: '#6366f1' },
                  { label: 'Calificación',value: `${Number(details.scorePercentage).toFixed(1)}%`,
                    color: details.scorePercentage >= 70 ? '#22c55e' : '#ef4444' },
                ].map(item => (
                  <div key={item.label} style={{
                    flex: '1 1 70px', background: '#fff',
                    borderRadius: '10px', padding: '10px 14px',
                    border: `1.5px solid ${item.color}33`,
                    textAlign: 'center',
                  }}>
                    <div style={{ fontSize: '1.25rem', fontWeight: 800, color: item.color }}>
                      {item.value}
                    </div>
                    <div style={{ fontSize: '0.72rem', color: '#94a3b8', marginTop: '2px' }}>
                      {item.label}
                    </div>
                  </div>
                ))}
              </div>

              {/* Lista de preguntas */}
              {details.details?.map((d, i) => (
                <DetailRow key={d.detailId} detail={d} index={i} />
              ))}
            </>
          )}
        </div>
      )}
    </div>
  );
}

// ── Componente principal ─────────────────────────────────────────────────────
export default function EvaluationHistory({ user }) {
  const [evaluations, setEvaluations] = useState([]);
  const [loading,     setLoading]     = useState(true);
  const [error,       setError]       = useState('');

  const fetchHistory = useCallback(async () => {
    setLoading(true);
    setError('');
    try {
      const data = await api.getEvaluations(user.username);
      setEvaluations(data);
    } catch (e) {
      setError(e.message);
    } finally {
      setLoading(false);
    }
  }, [user.username]);

  useEffect(() => { fetchHistory(); }, [fetchHistory]);

  return (
    <div style={{ maxWidth: '760px', margin: '0 auto', padding: '0 16px 40px' }}>

      {/* Encabezado */}
      <div style={{
        display: 'flex', alignItems: 'center', justifyContent: 'space-between',
        marginBottom: '20px', flexWrap: 'wrap', gap: '10px',
      }}>
        <div>
          <h5 style={{ margin: 0, fontWeight: 800, fontSize: '1.1rem', color: '#1e293b' }}>
            📋 Historial de Evaluaciones
          </h5>
          <small style={{ color: '#94a3b8' }}>
            {evaluations.length} evaluación{evaluations.length !== 1 ? 'es' : ''} registrada{evaluations.length !== 1 ? 's' : ''}
          </small>
        </div>
        <button
          id="btn-refresh-history"
          onClick={fetchHistory}
          disabled={loading}
          style={{
            background: '#f1f5f9', color: '#475569',
            border: '1.5px solid #cbd5e1', borderRadius: '10px',
            padding: '7px 16px', fontWeight: 600, fontSize: '0.85rem',
            cursor: loading ? 'not-allowed' : 'pointer',
          }}
        >
          {loading ? '...' : '🔄 Actualizar'}
        </button>
      </div>

      {/* Estado: cargando */}
      {loading && (
        <div style={{ textAlign: 'center', padding: '40px', color: '#94a3b8' }}>
          <div className="spinner-border text-primary" role="status"></div>
          <p style={{ marginTop: '12px' }}>Cargando historial...</p>
        </div>
      )}

      {/* Estado: error */}
      {error && !loading && (
        <div style={{
          background: '#fff5f5', border: '1px solid #fecaca',
          borderRadius: '12px', padding: '16px', color: '#dc2626', fontSize: '0.9rem',
        }}>
          ⚠ {error}
        </div>
      )}

      {/* Estado: vacío */}
      {!loading && !error && evaluations.length === 0 && (
        <div style={{
          textAlign: 'center', padding: '50px 20px',
          background: '#f8faff', borderRadius: '16px',
          border: '1.5px dashed #c7d2fe',
        }}>
          <div style={{ fontSize: '3rem', marginBottom: '12px' }}>📝</div>
          <p style={{ color: '#64748b', margin: 0, fontWeight: 600 }}>
            Aún no has completado ninguna evaluación.
          </p>
          <p style={{ color: '#94a3b8', fontSize: '0.85rem', marginTop: '6px' }}>
            Completa tu primera evaluación y aparecerá aquí.
          </p>
        </div>
      )}

      {/* Lista de evaluaciones */}
      {!loading && evaluations.map((ev, i) => (
        <EvaluationCard
          key={ev.evaluationId}
          evaluation={ev}
          userId={user.username}
          index={i}
        />
      ))}
    </div>
  );
}
